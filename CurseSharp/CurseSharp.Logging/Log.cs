using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;
using WritePath = System.String;
using LogContents = System.String;

namespace CurseSharp.Logging
{
    public static class Log
    {
        /// <summary>
        /// When true, logs are written to the 'Output' window in Visual Studio
        /// </summary>
        private static bool writeToDebugWindow = true;
        /// <summary>
        /// When true, the logs are written to the 'Console' window
        /// </summary>
        private static bool writeToConsoleWindow = true;
        /// <summary>
        /// When true, the logs are written to the specified '{logBasePath}\{LogErrorLevel}\{currentUtcShortDate}.log'
        /// </summary>
        private static bool writeToDisk = true;
        /// <summary>
        /// Log queue that needs to be written to disk. 
        /// </summary>
        private static Dictionary<WritePath, HashSet<LogContents>> logQueue = new Dictionary<string, HashSet<string>>();
        /// <summary>
        /// Interval that triggers log writer
        /// </summary>
        private static Timer logQueueWriteTimer = new Timer(3000);
        /// <summary>
        /// State manager to make sure that multiple writes cannot occur at the same time, if write exceeds the time it takes to trigger another timer.
        /// </summary>
        private static bool skipIteration = false;
        /// <summary>
        /// Base location to write log files. When no drive is specified, it will log from the application's running directory.
        /// </summary>
        private static string logBasePath = $@"{AppDomain.CurrentDomain.BaseDirectory}Logs\";
        /// <summary>
        /// Minimum log level required to take action on log request. Used for filtering non-required messages.
        /// </summary>
        private static LogLevel minLogLevel = LogLevel.Verbose;

        /// <summary>
        /// Criticality of the log
        /// </summary>
        public enum LogLevel
        {
            Verbose = 0,
            Debug = 1,
            Trace = 2,
            Info = 3,
            Warning = 4,
            Error = 5,
            Critical = 6,
            Fatal = 7
        }

        static Log()
        {
            logQueueWriteTimer.Elapsed += new ElapsedEventHandler(LogWriteQueueHandler);
            logQueueWriteTimer.Start();
        }

        /// <summary>
        /// Turns Console logging on/off
        /// </summary>
        /// <param name="echoResponse">
        /// True: On
        /// False: Off
        /// </param>
        public static void SetEchoConsole(bool echoResponse)
        {
            writeToConsoleWindow = echoResponse;
        }

        /// <summary>
        /// Turns Output Window logging on/off
        /// </summary>
        /// <param name="echoResponse">
        /// True: On
        /// False: Off
        /// </param>
        public static void SetEchoOutputWindow(bool echoResponse)
        {
            writeToDebugWindow = echoResponse;
        }

        /// <summary>
        /// Turns disk logging on/off
        /// </summary>
        /// <param name="echoResponse">
        /// True: On
        /// False: Off
        /// </param>
        public static void SetEchoDisk(bool echoResponse)
        {
            writeToDisk = echoResponse;
        }

        public static void SetMinLogLevel(LogLevel logLevel)
        {
            minLogLevel = logLevel;
        }

        /// <summary>
        /// Forces the log queue to be flushed immediately
        /// </summary>
        public static void Flush()
        {
            LogWriteQueueHandler(null, null);
        }

        /// <summary>
        /// Processes log queue and writes files to disk
        /// </summary>
        private static void LogWriteQueueHandler(object sender, ElapsedEventArgs e)
        {
            try
            {
                if(skipIteration)
                {
                    return;
                }

                skipIteration = true;

                var localQueue = new Dictionary<string, List<string>>();
                lock(logQueue)
                {
                    foreach(var logEntry in logQueue)
                    {
                        if(logQueue.Count > 0)
                        {
                            if(!localQueue.ContainsKey(logEntry.Key))
                            {
                                localQueue.Add(logEntry.Key, new List<string>());
                            }
                            localQueue[logEntry.Key].AddRange(logEntry.Value);
                        }
                    }
                    logQueue.Clear();
                }
                foreach(var file in localQueue)
                {
                    var directory = Path.GetDirectoryName(file.Key);
                    if(!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    using(var stream = new FileStream(file.Key, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        using(var writer = new StreamWriter(stream, Encoding.UTF8))
                        {
                            foreach(var line in file.Value)
                            {
                                writer.WriteLine($"{line}");
                            }
                            writer.Flush();
                        }
                    }
                }
                skipIteration = false;
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                skipIteration = false;
            }
            finally
            {
                skipIteration = false;
            }
        }

        /// <summary>
        /// Enqueues a verbose log entry
        /// </summary>
        public static void Verbose(string message)
        {
            if(LogLevel.Verbose >= minLogLevel)
            {
                WriteLog(message, LogLevel.Verbose);
            }
        }

        /// <summary>
        /// Enqueues a debug log entry
        /// </summary>
        public static void Debug(string message)
        {
            if(LogLevel.Debug >= minLogLevel)
            {
                WriteLog(message, LogLevel.Debug);
            }
        }

        /// <summary>
        /// Enqueues a trace log entry
        /// </summary>
        public static void Trace(string message)
        {
            if(LogLevel.Trace >= minLogLevel)
            {
                WriteLog(message, LogLevel.Trace);
            }
        }

        /// <summary>
        /// Enqueues an info log entry
        /// </summary>
        public static void Info(string message)
        {
            if(LogLevel.Info >= minLogLevel)
            {
                WriteLog(message, LogLevel.Info);
            }
        }

        /// <summary>
        /// Enqueues a warning log entry
        /// </summary>
        public static void Warning(string message)
        {
            if(LogLevel.Warning >= minLogLevel)
            {
                WriteLog(message, LogLevel.Warning);
            }
        }

        /// <summary>
        /// Enqueues an error log entry
        /// </summary>
        public static void Error(string message)
        {
            if(LogLevel.Error >= minLogLevel)
            {
                WriteLog(message, LogLevel.Error);
            }
        }

        /// <summary>
        /// Enqueues a critical log entry
        /// </summary>
        public static void Critical(string message)
        {
            if(LogLevel.Critical >= minLogLevel)
            {
                WriteLog(message, LogLevel.Critical);
            }
        }

        /// <summary>
        /// Enqueues a fatal log entry
        /// </summary>
        public static void Fatal(string message)
        {
            if(LogLevel.Fatal >= minLogLevel)
            {
                WriteLog(message, LogLevel.Fatal);
            }
        }

        /// <summary>
        /// Enqueues the log to the write queue based on the log level
        /// </summary>
        private static void WriteLog(string message, LogLevel logLevel)
        {
            var logMessage = $"[{DateTime.UtcNow}|{Enum.GetName(typeof(LogLevel), logLevel)}] {message}";
            if(writeToDebugWindow)
            {
                System.Diagnostics.Debug.Print(logMessage);
            }
            if(writeToConsoleWindow)
            {
                Console.WriteLine(logMessage);
            }

            if(writeToDisk)
            {
                lock(logQueue)
                {
                    var logPath = $@"{logBasePath}{Enum.GetName(typeof(LogLevel), logLevel)}\{DateTime.UtcNow.ToShortDateString().Replace('/', '-')}.log";
                    if(!logQueue.ContainsKey(logPath))
                    {
                        logQueue.Add(logPath, new HashSet<string>());
                    }
                    logQueue[logPath].Add(logMessage);
                }
            }
        }
    }
}
