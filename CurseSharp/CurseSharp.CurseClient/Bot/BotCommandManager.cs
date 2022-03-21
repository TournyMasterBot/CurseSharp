using CurseSharp.CurseClient.Models.BotModels;
using System;
using System.Collections.Generic;

namespace CurseSharp.CurseClient.Bot
{
    public class BotCommandManager
    {
        public Dictionary<string, BotCommandModel> Commands = new Dictionary<string, BotCommandModel>();

        /// <summary>
        /// Add a command to the 'Commands' dictionary
        /// </summary>
        public void AddCommand(BotCommandModel command)
        {
            if(string.IsNullOrWhiteSpace(command.CommandTrigger))
            {
                throw new InvalidOperationException("Command trigger cannot be null or blank.");
            }
            if(string.IsNullOrWhiteSpace(command.CommandCall))
            {
                throw new InvalidOperationException("Command call cannot be null or blank");
            }
            if(string.IsNullOrWhiteSpace(command.HelpText))
            {
                throw new InvalidOperationException("Command help text cannot be null or blank");
            }
            if(command.ExecuteAction == null)
            {
                throw new InvalidOperationException("Command execute action cannot be null");
            }
            var commandKey = $"{command.CommandTrigger}{command.CommandCall}".ToLower();
            if(Commands.ContainsKey(commandKey))
            {
                throw new InvalidOperationException($"Command {commandKey} already exists. Please use a different command key.");
            }
#if VERBOSE_LOGGING
            if(commandKey != $"{command.CommandTrigger}{command.CommandCall}")
            {
                Logging.Log.Verbose($"Changing command key to lowercase. {commandKey}");
            }
#endif

            Commands.Add(commandKey, command);
        }

        /// <summary>
        /// Removes a command from the 'Commands' dictionary. The command name must be $"{CommandTrigger}{CommandCall}" format (Ex: !commands)
        /// </summary>
        /// <returns>
        /// True: Successfully Removed Command
        /// False: Failed to add command
        /// Null: Command does not exist
        /// </returns>
        public bool? RemoveCommand(string commandName)
        {
            try
            {
                var commandname = commandName.ToLower();
                if(!Commands.ContainsKey(commandname))
                {
                    return null;
                }
                Commands.Remove(commandname);
                return true;
            }
            catch(Exception ex)
            {
#if VERBOSE_LOGGING
                Logging.Log.Error(ex.ToString());
#endif
                return false;
            }
        }
    }
}
