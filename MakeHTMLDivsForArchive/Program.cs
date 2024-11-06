using System.Text;

var outputPath = @"C:\Users\Quinn\Pictures\avalon\TRP_PROAVL_IST AVATAR ARCHIVE\avatararchive.html";

string username = "-";

const int size = 96;

StringBuilder sb = new();
sb.Append(
    "<!DOCTYPE html>\r\n<html lang=\"en\">\r\n" +
    "\t<head>\r\n" +
    "\t\t<meta charset=\"UTF-8\">\r\n" +
    "\t\t<meta name=\"viewport\" content=\"initial-scale=1\">\r\n" +
    "\t\t<title>Avalon Avatar Archive</title>\r\n" +
    "\t\t<link rel=\"icon\" href=\"PROAVALON/base-3-res.png\">" +
    "\t\t<script src=\"js/jquery.3.7.0.min.js\"></script>\r\n" +
    "\t\t<style>\r\n" +
    "\t\t@font-face {\r\n" +
    "\t\t\tfont-family: 'Special Elite';\r\n" +
    "\t\t\tsrc: url(font/SpecialElite.ttf);\r\n" +
    "\t\t}\r\n" +
    "\t\t.main-title {\r\n" +
    "\t\t\tmargin: 0em auto;\r\n" +
    "\t\t\tpadding: 0;\r\n" +
    "\t\t}\r\n" +
    "\t\t.main-title img {\r\n" +
    "\t\t\twidth: 100%;\r\n" +
    "\t\t}\r\n" +
    "\t\t.site-name {\r\n" +
    "\t\t\ttext-align: center;\r\n" +
    "\t\t\tfont-size: 80pt;\r\n" +
    "\t\t\tfont-weight: bold;\r\n" +
    "\t\t\tcolor: white;\r\n" +
    "\t\t\t-webkit-text-stroke-width: 0.5px;\r\n" +
    "\t\t\t-webkit-text-stroke-color: black;\r\n" +
    "\t\t\tmargin-top: 0.5cm;\r\n" +
    "\t\t\tmargin-bottom: 0.5cm;\r\n" +
    "\t\t}\r\n" +
    "\t\tbody {\r\n" +
    "\t\t\tbackground-color: #4477bb;\r\n" +
    "\t\t\tfont-family: 'Special Elite';\r\n" +
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
    "\t\t</style>\r\n" +
    "\t</head>\r\n" +
    "\t<body>\r\n" +
    "\t\t<p class=\"main-title\"><img src=\"title-img.png\"></p>\r\n"
    );
var folders = new[] { "PROAVALON", "TRP", "AVALON_IST" };
var sitenames = new[] { "ProAvalon", "TheResistancePlus", "AvalonIst" };
var filenames = new[] { "proavfiles.txt", "trpfiles.txt", "avalonistfiles.txt" };
for (int folder = 0; folder < folders.Length; folder++)
{
    var inputPath = $@"C:\Users\Quinn\Pictures\avalon\TRP_PROAVL_IST AVATAR ARCHIVE\{filenames[folder]}";
    var lines = File.ReadAllLines(inputPath);
    var prevLine = "";
    if (folder != 0)
        sb.Append("\t\t</div>\r\n");
    sb.Append($"\t\t<p class=\"site-name\">{sitenames[folder]}</p>\r\n");
    sb.Append("\t\t<div class=\"players\">\r\n");
    for (int i = 0; i < lines.Length; i++)
    {
        if (!lines[i].StartsWith(username) || lines[i].Length != prevLine.Length)
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
    sb.Append("\t\t\t\t</div>\r\n\t\t\t</div>\n");
}
sb.Append("\t\t</div>\r\n\t</body>\r\n</html>");

File.WriteAllText(outputPath, sb.ToString());