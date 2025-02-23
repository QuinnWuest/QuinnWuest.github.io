using System.Text;

var outputPath = @"C:\Users\Quinn\Desktop\QW.github.io\Avalon\avatararchive.html";

const int size = 96;

StringBuilder sb = new();
sb.Append(
    "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n" +
    "\t<head>\r\n" +
    "\t\t<meta charset=\"UTF-8\">\r\n" +
    "\t\t<meta name=\"viewport\" content=\"initial-scale=1\">\r\n" +
    "\t\t<title>Avalon Avatar Archive</title>\r\n" +
    "\t\t<link rel=\"icon\" href=\"BASE/base-4-res.png\">\r\n" +
    "\t\t<script src=\"js/jquery.3.7.0.min.js\"></script>\r\n" +
    "\t\t<style>\r\n" +
    "\t\t@font-face {\r\n" +
    "\t\t\tfont-family: 'Merriwether';\r\n" +
    "\t\t\tsrc: url(font/merriweather.light.ttf);\r\n" +
    "\t\t}\r\n" +
    "\t\t.main-title {\r\n" +
    "\t\t\ttext-align: center;\r\n" +
    "\t\t\tfont-size: 100pt;\r\n" +
    "\t\t\tmargin-top: 0.5cm;\r\n" +
    "\t\t\tmargin-bottom: 0.5cm;\r\n" +
    "\t\t\tbackground: linear-gradient(90deg, rgba(60, 255, 200, 1) 0%, rgba(180, 100, 255, 1) 100%);\r\n" +
    "\t\t\t\t-webkit-background-clip: text;\r\n" +
    "\t\t\t\tbackground-clip: text;\r\n" +
    "\t\t\t\t-webkit-text-fill-color: transparent;\r\n" +
    "\t\t\t-webkit-text-stroke-width: 2pt;\r\n" +
    "\t\t\t-webkit-text-stroke-color: black;\r\n" +
    "\t\t}\r\n" +
    "\t\t.main-title img {\r\n" +
    "\t\t\twidth: 100%;\r\n" +
    "\t\t}\r\n" +
    "\t\t.site-name {\r\n" +
    "\t\t\ttext-align: center;\r\n" +
    "\t\t\tfont-size: 80pt;\r\n" +
    "\t\t\tcolor: white;\r\n" +
    "\t\t\tmargin-top: 0.5cm;\r\n" +
    "\t\t\tmargin-bottom: 0.5cm;\r\n" +
    "\t\t}\r\n" +
    "\t\t.tourney-number {\r\n" +
    "\t\t\ttext-align: center;\r\n" +
    "\t\t\tfont-size: 40pt;\r\n" +
    "\t\t\tcolor: white;\r\n" +
    "\t\t\tmargin-top: 0.5cm;\r\n" +
    "\t\t\tmargin-bottom: 0.5cm;\r\n" +
    "\t\t}\r\n" +
    "\t\tbody {\r\n" +
    "\t\t\tbackground-color: #4477bb;\r\n" +
    "\t\t\tfont-family: 'Merriwether';\r\n" +
    "\t\t}\r\n" +
    "\t\t.players {\r\n" +
    "\t\t\tmargin: auto;\r\n" +
    "\t\t\tjustify-content: center;\r\n" +
    "\t\t\tdisplay: flex;\r\n" +
    "\t\t\tflex-direction: row;\r\n" +
    "\t\t\talign-items: center;\r\n" +
    "\t\t\tflex-wrap: wrap;\r\n" +
    "\t\t}\r\n" +
    "\t\t.player {\r\n" +
    "\t\t\tmargin: 0.25cm;\r\n" +
    "\t\t\tdisplay: flex;\r\n" +
    "\t\t\tflex-direction: column;\r\n" +
    "\t\t\talign-items: center;\r\n" +
    "\t\t\tborder: 4px solid black;\r\n" +
    "\t\t\tborder-radius: 1cm;\r\n" +
    "\t\t\tbackground-color: #aaddff;\r\n" +
    "\t\t\tpadding: 0.5cm;\r\n" +
    "\t\t}\r\n" +
    "\t\t.player-name {\r\n" +
    "\t\t\ttext-align: center;\r\n" +
    "\t\t\tfont-size: 20pt;\r\n" +
    "\t\t\tmargin: 0em auto;\r\n" +
    "\t\t\tposition: relative;\r\n" +
    "\t\t}\r\n" +
    "\t\t.player-icons {\r\n" +
    "\t\t\tdisplay: flex;\r\n" +
    "\t\t\tflex-wrap: wrap;\r\n" +
    "\t\t\tmargin: 0em auto;\r\n" +
    "\t\t\tposition: relative;\r\n" +
    "\t\t\talign-items: center;\r\n" +
    "\t\t\tjustify-content: center;\r\n" +
    "\t\t}\r\n" +
    "\t\t.player-icons img {\r\n" +
    "\t\t\tpadding: 0;\r\n" +
    $"\t\t\theight: {size}px;\r\n" +
    "\t\t}\r\n" +
    "\t\t.player-icon {\r\n" +
    $"\t\t\twidth: {size}px;\r\n" +
    "\t\t\tdisplay: flex;\r\n" +
    "\t\t\tposition: relative;\r\n" +
    "\t\t\talign-items: center;\r\n" +
    "\t\t\tjustify-content: center;\r\n" +
    "\t\t}\r\n" +
    "\t\t.notes {\r\n" +
    "\t\t\tflex-direction: column;\r\n" +
    "\t\t\tborder: 4px solid black;\r\n" +
    "\t\t\tborder-radius: 1cm;\r\n" +
    "\t\t\tbackground-color: #aaddff;\r\n" +
    "\t\t\tfont-size: 14pt;\r\n" +
    "\t\t\tpadding: 0.5cm;\r\n" +
    "\t\t}\r\n" +
    "\t\t</style>\r\n" +
    "\t</head>\r\n" +
    "\t<body>\r\n" +
    "\t\t<p class=\"main-title\">Avalon Avatar Archive</p>\r\n"
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