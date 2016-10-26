# CurseSharp Overview
This project is designed to enable developers to create a bot that can connect to the Curse Client. This project is just in it's starting phase, so should not be used for production use at this time.

# Curse Channel (Unofficial Curse API Developers)
https://curse.com/invite/viIE41997UWf1af4ksSkag

# Project Structure
## CurseSharp.CurseClient
Interface to Curse Web Api and Curse WebSocket. This project contains the actual api/websocket models and bot implementation.

## CurseSharp.Demo
Basic bot usage, intended as the applications starting point.

## CurseSharp.Logging
Log method for the bot. You can change logging options in this project to manage output to 'Console, Output, Disk' locations

## CurseSharp.TestClient
Internal developer project, this project can be safely removed if your solution file includes a reference to it - or create a blank/empty project with the same name to prevent pulls in the future if you merge updates.

## CurseSharp.UI
Windows Form example bot. Intended usage is for basic moderation tools and channel management.

###### CurseSharp is an unofficial client designed to connect to Curse servers.