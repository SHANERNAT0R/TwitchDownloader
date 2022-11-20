﻿using CommandLine;
using TwitchDownloaderCore.Options;

namespace TwitchDownloaderCLI.Modes.Arguments
{

    [Verb("chatdownload", HelpText = "Downloads the chat from a VOD or clip")]
    public class ChatDownloadArgs
    {
        [Option('u', "id", Required = true, HelpText = "The ID of the VOD or clip to download that chat of.")]
        public string Id { get; set; }

        [Option('o', "output", Required = true, HelpText = "Path to output file. File extension will be used to determine download type. Valid extensions are json, html, and txt.")]
        public string OutputFile { get; set; }

        [Option('b', "beginning", HelpText = "Time in seconds to crop beginning.")]
        public int CropBeginningTime { get; set; }

        [Option('e', "ending", HelpText = "Time in seconds to crop ending.")]
        public int CropEndingTime { get; set; }
        
        [Option('E', "embed-emotes", Default = false, HelpText = "Embed emotes into the chat download.")]
        public bool EmbedEmotes { get; set; }

        [Option("bttv", Default = true, HelpText = "Enable BTTV embedding in chat download. Requires -E / --embed-emotes!")]
        public bool? BttvEmotes { get; set; }
        
        [Option("ffz", Default = true, HelpText = "Enable FFZ embedding in chat download. Requires -E / --embed-emotes!")]
        public bool? FfzEmotes { get; set; }
        
        [Option("stv", Default = true, HelpText = "Enable 7tv embedding in chat download. Requires -E / --embed-emotes!")]
        public bool? StvEmotes { get; set; }

        [Option("timestamp", Default = false, HelpText = "Enable timestamps for .txt chat downloads.")]
        public bool Timestamp { get; set; }

        [Option("timestamp-format", Default = TimestampFormat.Relative, HelpText = "Sets the timestamp format for .txt chat logs. Valid values are Utc, Relative, and None")]
        public TimestampFormat TimeFormat { get; set; }

        [Option("chat-connections", Default = 4, HelpText = "Number of downloading connections for chat")]
        public int ChatConnections { get; set; }
    }
}