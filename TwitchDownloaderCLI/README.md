# TwitchDownloaderCLI
A cross platform command line tool that can do the main functions of the GUI program, which can download VODs/Clips/Chats and render chats.

- [TwitchDownloaderCLI](#twitchdownloadercli)
  - [Arguments for mode videodownload](#arguments-for-mode-videodownload)
  - [Arguments for mode clipdownload](#arguments-for-mode-clipdownload)
  - [Arguments for mode chatdownload](#arguments-for-mode-chatdownload)
  - [Arguments for mode chatupdate](#arguments-for-mode-chatupdate)
  - [Arguments for mode chatrender](#arguments-for-mode-chatrender)
  - [Arguments for mode ffmpeg](#arguments-for-mode-ffmpeg)
  - [Arguments for mode cache](#arguments-for-mode-cache)
  - [Example Commands](#example-commands)
  - [Additional Notes](#additional-notes)

---

## Arguments for mode videodownload
<sup>Downloads a stream VOD or highlight from Twitch</sup>

**-u / --id (REQUIRED)**
The ID of the VOD to download, currently only accepts Integer IDs and will accept URLs in the future.

**-o / --output (REQUIRED)**
File the program will output to.

**-q / --quality**
The quality the program will attempt to download, for example "1080p60", if not found will download highest quality stream.

**-b / --beginning**
Time in seconds to crop beginning. For example if I had a 10 second stream but only wanted the last 7 seconds of it I would use `-b 3` to skip the first 3 seconds.

**-e / --ending**
Time in seconds to crop ending. For example if I had a 10 second stream but only wanted the first 4 seconds of it I would use `-e 4` to end on the 4th second.

Extra example, if I wanted only seconds 3-6 in a 10 second stream I would do `-b 3 -e 6`

**-t / --threads**
(Default: 10) Number of download threads.

**--oauth**
OAuth access token to download subscriber only VODs. <u>**DO NOT SHARE YOUR OUATH WITH ANYONE.**</u>

**--ffmpeg-path**
Path to ffmpeg executable.

**--temp-path**
Path to temporary folder for cache.


## Arguments for mode clipdownload
<sup>Downloads a clip from Twitch</sup>

**-u / --id (REQUIRED)**
The ID of the Clip to download, currently only accepts the string identifier and will accept URLs in the future.

**-o / --output (REQUIRED)**
File the program will output to.

**-q / --quality**
The quality the program will attempt to download, for example "1080p60", if not found will download highest quality video.


## Arguments for mode chatdownload
<sup>Downloads the chat of a VOD, highlight, or clip</sup>

**-u / --id (REQUIRED)**
The ID of the VOD or clip to download. Does not currently accept URLs.

**-o / --output (REQUIRED)**
File the program will output to. File extension will be used to determine download type. Valid extensions are: `json`, `html`, and `txt`.

**-b / --beginning**
Time in seconds to crop beginning. For example if I had a 10 second stream but only wanted the last 7 seconds of it I would use `-b 3` to skip the first 3 seconds.

**-e / --ending**
Time in seconds to crop ending. For example if I had a 10 second stream but only wanted the first 4 seconds of it I would use `-e 4` to end on the 4th second.

**-E / --embed-images**
(Default: false) Embed first party emotes, badges, and cheermotes into the download file for offline rendering. Useful for archival purposes, file size will be larger.

**--bttv**
(Default: true) BTTV emote embedding. Requires `-E / --embed-images`.

**--ffz**
(Default: true) FFZ emote embedding. Requires `-E / --embed-images`.

**--stv**
(Default: true) 7TV emote embedding. Requires `-E / --embed-images`.

**--timestamp-format**
(Default: Relative) Sets the timestamp format for .txt chat logs. Valid values are: `Utc`, `Relative`, and `None`.

**--chat-connections**
(Default: 4) The number of parallel downloads for chat.


## Arguments for mode chatupdate
<sup>Updates the embeded emotes, badges, bits, and crops of a chat download and/or converts a JSON chat to another format</sup>

**-i / --input (REQUIRED)**
Path to input file. Valid extensions are: `json`.

**-o / --output (REQUIRED)**
Path to output file. File extension will be used to determine new chat type. Valid extensions are: `json`, `html`, and `txt`.

**-E / --embed-missing**
(Default: false) Embed missing emotes, badges, and cheermotes. Already embedded images will be untouched.

**-R / --replace-embeds**
(Default: false) Replace all embedded emotes, badges, and cheermotes in the file. All embedded data will be overwritten!

**b / --beginning**
(Default: -1) New time in seconds for chat beginning. Comments may be added but not removed. -1 = No crop.

**-e / --ending**
(Default: -1) New time in seconds for chat beginning. Comments may be added but not removed. -1 = No crop.

**--bttv**
(Default: true) Enable embedding BTTV emotes.

**--ffz**
(Default: true) Enable embedding FFZ emotes.

**--stv**
(Default: true) Enable embedding 7TV emotes.

**--timestamp-format**
(Default: Relative) Sets the timestamp format for .txt chat logs. Valid values are: `Utc`, `Relative`, and `None`.

**--temp-path**
Path to temporary folder for cache.


## Arguments for mode chatrender
<sup>Renders a chat JSON as a video</sup>

**-i / --input (REQUIRED)**
Path to JSON chat file input.

**-o / --output (REQUIRED)**
File the program will output to.

**--background-color**
(Default: #111111) Color of background in HEX string format.

**--message-color**
(Default: #ffffff) Color of messages in HEX string format.

**-w / --chat-width**
(Default: 350) Width of chat render.

**-h / --chat-height**
(Default: 600) Height of chat render.

**--bttv**
(Default: true) Enable BTTV emotes.

**--ffz**
(Default: true) Enable FFZ emotes.

**--stv**
(Default: true) Enable 7TV emotes.

**--sub-messages**
(Default: true) Enable sub / re-sub messages.

**--badges**
(Default: true) Enable chat badges.

**--outline**
(Default: false) Enable outline around chat messages.

**--outline-size**
(Default: 4) Size of outline if outline is enabled.

**-f / --font**
(Default: Inter Embedded) Font to use.

**--font-size**
(Default: 12) Font size.

**--message-fontstyle**
(Default: normal) Font style of message. Valid values are **normal**, **bold**, and **italic**.

**--username-fontstyle**
(Default: bold) Font style of username. Valid values are **normal**, **bold**, and **italic**.

**--timestamp**
(Default: false) Enables timestamps to left of messages, similar to VOD chat on Twitch.

**--generate-mask**
(Default: false) Generates a mask file of the chat in addition to the rendered chat.

**--framerate**
(Default: 30) Framerate of the render.

**--update-rate**
(Default: 0.2) Time in seconds to update chat render output.

**--input-args**
(Default: -framerate {fps} -f rawvideo -analyzeduration {max_int} -probesize {max_int} -pix_fmt bgra -video_size {width}x{height} -i -) Input arguments for ffmpeg chat render.

**--output-args**
(Default: -c:v libx264 -preset veryfast -crf 18 -pix_fmt yuv420p "{save_path}") Output arguments for ffmpeg chat render.

**--ignore-users**
(Default: ) List of usernames to ignore when rendering, separated by commas.

**--badge-filter**
(Default: 0) Bitmask of types of Chat Badges to filter out. Add the numbers of the types of badges you want to filter. For example, to filter out Moderator and Broadcaster badges only enter the value of 6.

Other = `1`, Broadcaster = `2`, Moderator = `4`, VIP = `8`, Subscriber = `16`, Predictions = `32`, NoAudioVisual = `64`, PrimeGaming = `128`

**--offline**
Render completely offline using only embedded emotes, badges, and bits from the input json.

**--ffmpeg-path**
Path to ffmpeg executable.

**--temp-path**
Path to temporary folder for cache.

**--verbose-ffmpeg**
Prints every message from ffmpeg.


## Arguments for mode ffmpeg
<sup>Manage standalone ffmpeg</sup>

**-d / --download**
(Default: false) Downloads ffmpeg as a standalone file.


## Arguments for mode cache
<sup>Manage the working cache.</sup>

**-c / --clear**
(Default: false) Clears the default cache folder.

**--force-clear**
(Default: false) Clears the default cache folder, bypassing the confirmation prompt.

---

## Example Commands
<sup>Examples of typical use cases</sup>

Download a VOD with defaults

    TwitchDownloaderCLI videodownload --id 612942303 -o video.mp4

Download a Clip with defaults

    TwitchDownloaderCLI clipdownload --id NurturingCalmHamburgerVoHiYo -o clip.mp4

Download a Chat JSON with embeded emotes/badges from Twitch and emotes from Bttv

    TwitchDownloaderCLI chatdownload --id 612942303 --embed-images --bttv=true --ffz=false --stv=false -o chat.json

Download a Chat as plain text with timestamps

    TwitchDownloaderCLI chatdownload --id 612942303 --timestamp-format Relative -o chat.txt

Add embeds to a chat file that was downloaded without embeds

    TwitchDownloaderCLI chatupdate -i chat.json -o chat_embedded.json --embed-missing

Convert a JSON chat file to HTML

    TwitchDownloaderCLI chatupdate -i chat.json -o chat.html

Render a chat with defaults

    TwitchDownloaderCLI chatrender -i chat.json -o chat.mp4

Render a chat with custom video settings and message outlines

    TwitchDownloaderCLI chatrender -i chat.json -h 1440 -w 720 --framerate 60 --outline -o chat.mp4

Render a chat with custom ffmpeg arguments

    TwitchDownloaderCLI chatrender -i chat.json --output-args='-c:v libx264 -preset veryfast -crf 18 -pix_fmt yuv420p "{save_path}"' -o chat.mp4

---

## Additional Notes

String arguments, such as output file, that contain spaces should be wrapped in double quotes <kbd>"</kbd> .

Default true boolean flags must be assigned: `--default-true-flag=false`. Default false boolean flags should still be raised normally: `--default-false-flag`

For Linux users, ensure both `fontconfig` and `libfontconfig1` are installed. `apt-get install fontconfig libfontconfig1` on Ubuntu.