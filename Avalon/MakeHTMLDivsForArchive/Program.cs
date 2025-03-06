using System.Text;

var outputPath = @"C:\Users\Quinn\Desktop\QW.github.io\Avalon\avatararchive.html";

const int size = 96;

StringBuilder sb = new();
sb.Append(
    $@"<!DOCTYPE html>
	<html lang=""en"">
		<head>
			<meta charset=""UTF-8"">
			<meta name=""viewport"" content=""initial-scale=1"">
			<title>Avalon Avatar Archive</title>
			<link rel=""icon"" href=""BASE/ProAvalon-2-res.png"">
			<script src=""js/jquery.3.7.0.min.js""></script>
			<style>
			@font-face {{
				font-family: 'Merriwether';
				src: url(font/merriweather.light.ttf);
			}}
			.main-title {{
				text-align: center;
				font-size: 120pt;
				margin-top: 0.5cm;
				margin-bottom: 0.5cm;
				background: linear-gradient(90deg, rgba(60, 255, 200, 1) 0%, rgba(180, 100, 255, 1) 100%);
					-webkit-background-clip: text;
					background-clip: text;
					-webkit-text-fill-color: transparent;
				-webkit-text-stroke-width: 2pt;
				-webkit-text-stroke-color: black;
			}}
			.main-title img {{
				width: 100%;
			}}
			.site-name {{
				text-align: center;
				font-size: 80pt;
				color: white;
				margin-top: 0.5cm;
				margin-bottom: 0.5cm;
			}}
			.tourney-number {{
				text-align: center;
				font-size: 40pt;
				color: white;
				margin-top: 0.5cm;
				margin-bottom: 0.5cm;
			}}
			body {{
				background-color: #4477bb;
				font-family: 'Merriwether';
			}}
			.players {{
				margin: auto;
				justify-content: center;
				display: flex;
				flex-direction: row;
				align-items: center;
				flex-wrap: wrap;
			}}
			.player {{
				margin: 0.25cm;
				display: flex;
				flex-direction: column;
				align-items: center;
				border: 4px solid black;
				border-radius: 1cm;
				background-color: #aaddff;
				padding: 0.5cm;
			}}
			.player-name {{
				text-align: center;
				font-size: 20pt;
				margin: 0em auto;
				position: relative;
			}}
			.player-icons {{
				display: flex;
				flex-wrap: wrap;
				margin: 0em auto;
				position: relative;
				align-items: center;
				justify-content: center;
			}}
			.player-icons img {{
				padding: 0;
				height: {size}px;
			}}
			.player-icon {{
				width: {size}px;
				display: flex;
				position: relative;
				align-items: center;
				justify-content: center;
			}}
			.notes {{
				flex-direction: column;
				border: 4px solid black;
				border-radius: 1cm;
				background-color: #aaddff;
				font-size: 14pt;
				padding: 0.5cm;
			}}
			</style>
		</head>
		<body>
			<p class=""main-title"">Avalon Avatar Archive</p>
	"
    );
var folders = new[] { "PROAVALON", "TRP", "AVALON_IST", "TOURNAMENT", "BASE" };
var sitenames = new[] { "ProAvalon", "TheResistancePlus", "AvalonIst", "Tournament Avatars", "Base Avatars" };
var filenames = new[] { "proavfiles.txt", "trpfiles.txt", "avalonistfiles.txt", "tournamentfiles.txt", "basefiles.txt" };

string inputPath;
string[] lines;
string prevLine;

string username = "-";
int tournamentNumber = -1;
int tournamentSize = -1;
int team = -1;
int teamNameIx = -1;
var teamNamePath = $@"C:\Users\Quinn\Desktop\QW.github.io\Avalon\tournamentteamnames.txt";
string[] teamNames = File.ReadAllLines(teamNamePath);

for (int folder = 0; folder < folders.Length; folder++)
{
    inputPath = $@"C:\Users\Quinn\Desktop\QW.github.io\Avalon\{filenames[folder]}";
    lines = File.ReadAllLines(inputPath);
    prevLine = "";
    if (folder != 0)
        sb.Append("\t\t</div>\r\n");
    if (folder != 3)
    {
        sb.Append($"\t\t<p class=\"site-name\">{sitenames[folder]}</p>\r\n");
        sb.Append("\t\t<div class=\"players\">\r\n");
        for (int i = 0; i < lines.Length; i++)
        {
            {
                if (!lines[i].StartsWith(username) || lines[i].IndexOf('-') != prevLine.IndexOf('-'))
                {
                    if (i != 0)
                        sb.Append("\t\t\t\t</div>\r\n\t\t\t</div>\n");
                    username = lines[i][..lines[i].IndexOf('-')];
                    //stupid case
                    if (username == "Ref")
                        username = "Ref-Rain";
                    sb.Append($"\t\t\t<div class=\"player\">\r\n\t\t\t\t<div class=\"player-name\">{username}</div>\r\n\t\t\t\t<div class=\"player-icons\">\n");
                    sb.Append($"\t\t\t\t\t<div class=\"player-icon\"><img src=\"{folders[folder]}/{lines[i]}\"></img></div>\n");
                }
                else
                    sb.Append($"\t\t\t\t\t<div class=\"player-icon\"><img src=\"{folders[folder]}/{lines[i]}\"></img></div>\n");
                prevLine = lines[i];
            }
        }
    }
    else
    {
        sb.Append($"\t\t<p class=\"site-name\">Tournament Avatars</p>\r\n");
        for (int i = 0; i < lines.Length; i++)
        {
            bool newTournament = false;
            bool newTeam = false;
            int tempSize = lines[i][0] - '0';
            if (!int.TryParse(lines[i].AsSpan(2, 2), out int tempNumber))
                tempNumber = lines[i][2] - '0';
            if (tournamentSize != tempSize || tournamentNumber != tempNumber)
            {
                newTournament = true;
                team = -1;
            }
            int tempTeam = lines[i][5] - '0';
            if (team != tempTeam)
                newTeam = true;
            if (newTournament)
            {
                if (tournamentNumber != -1)
                    sb.Append("\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t</div>\r\n");
                tournamentSize = tempSize;
                tournamentNumber = tempNumber;
                sb.Append($"\t\t<div class=\"tourney-number\">{tournamentSize}p Tournament #{tournamentNumber}</div>\r\n");
                sb.Append("\t\t<div class=\"players\">\r\n");
            }
            if (newTeam)
            {
                teamNameIx++;
                if (i != 0 && !newTournament)
                    sb.Append("\t\t\t\t</div>\r\n\t\t\t</div>\n");
                team = tempTeam;
                sb.Append($"\t\t\t<div class=\"player\">\r\n\t\t\t\t<div class=\"player-name\">{teamNames[teamNameIx].Substring(4)}</div>\r\n\t\t\t\t<div class=\"player-icons\">\n");
                sb.Append($"\t\t\t\t\t<div class=\"player-icon\"><img src=\"{folders[folder]}/{lines[i]}\"></img></div>\n");
            }
            else
            {
                sb.Append($"\t\t\t\t\t<div class=\"player-icon\"><img src=\"{folders[folder]}/{lines[i]}\"></img></div>\n");
            }
        }
    }
    sb.Append("\t\t\t\t</div>\r\n\t\t\t</div>\n");
}
sb.Append("\t\t</div>\r\n");
sb.Append($"\t<div>\r\n");
sb.Append($"\t\t<p class=\"site-name\">Notes & Credits</p>\r\n");
var notespath = $@"C:\Users\Quinn\Desktop\QW.github.io\Avalon\notesandcredits.txt";
var notes = File.ReadAllLines(notespath);

sb.Append($"\t\t\t<div class=\"notes\">\r\n");
for (int i = 0; i < notes.Length; i++)
{
    sb.Append($"\t\t\t{notes[i]}\r\n");
}
sb.Append($"\t\t\t</div>\r\n");

sb.Append("\t\t</div>\r\n\t</body>\r\n</html>");

File.WriteAllText(outputPath, sb.ToString());