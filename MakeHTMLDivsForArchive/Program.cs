using System.Text;

var inputPath = @"C:\Users\Quinn\Pictures\avalon\TRP_PROAVL_IST AVATAR ARCHIVE\filelist.txt";
var outputPath = @"C:\Users\Quinn\Pictures\avalon\TRP_PROAVL_IST AVATAR ARCHIVE\avatararchive.html";
var lines = File.ReadAllLines(inputPath);


string username = "-";

StringBuilder sb = new StringBuilder();
sb.Append("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\t<head>\r\n\t\t<meta charset=\"UTF-8\">\r\n\t\t<meta name=\"viewport\" content=\"initial-scale=1\">\r\n\t\t<title>Avalon Avatar Archive</title>\r\n\t\t<script src=\"js/jquery.3.7.0.min.js\"></script>\r\n\t\t<style>\r\n\t\t@font-face {\r\n\t\t\tfont-family: 'Special Elite';\r\n\t\t\tsrc: url(font/SpecialElite.ttf);\r\n\t\t}\r\n\t\t.main-title {\r\n\t\t\tfont-size: 75pt;\r\n\t\t\ttext-align: center;\r\n\t\t\tmargin-top: 1cm;\r\n\t\t\tmargin-bottom: -0.5cm;\r\n\t\t}\r\n\t\t.site-name {\r\n\t\t\ttext-align: center;\r\n\t\t\tfont-size: 40pt;\r\n\t\t\tmargin-bottom: 0.5cm;\r\n\t\t}\r\n\t\tbody {\r\n\t\t\tbackground-color: #4477bb;\r\n\t\t\tfont-family: 'Special Elite';\r\n\t\t}\r\n\t\t.players {\r\n\t\t\tmargin: auto;\r\n\t\t\tjustify-content: center;\r\n\t\t\tdisplay: flex;\r\n\t\t\tflex-direction: row;\r\n\t\t\talign-items: center;\r\n\t\t\tflex-wrap: wrap;\r\n\t\t}\r\n\t\t.player {\r\n\t\t\tmargin: 0.5cm;\r\n\t\t\tdisplay: flex;\r\n\t\t\tflex-direction: column;\r\n\t\t\talign-items: center;\r\n\t\t\tborder: 4px solid black;\r\n\t\t\tborder-radius: 1cm;\r\n\t\t\tbackground-color: #aaddff;\r\n\t\t\tpadding: 0.5cm;\r\n\t\t}\r\n\t\t.player-name {\r\n\t\t\ttext-align: center;\r\n\t\t\tfont-size: 20pt;\r\n\t\t\tmargin: 0em auto;\r\n\t\t\tposition: relative;\r\n\t\t}\r\n\t\t.player-icons {\r\n\t\t\tdisplay: flex;\r\n\t\t\tflex-wrap: wrap;\r\n\t\t\tmargin: 0em auto;\r\n\t\t\tposition: relative;\r\n\t\t\talign-items: center;\r\n\t\t\tjustify-content: center;\r\n\t\t}\r\n\t\t.player-icons img {\r\n\t\t\tpadding: 0;\r\n\t\t\theight: 128px;\r\n\t\t}\r\n\t\t.box {\r\n\t\t\twidth: 128px;\r\n\t\t\tdisplay: flex;\r\n\t\t\tposition: relative;\r\n\t\t\talign-items: center;\r\n\t\t\tjustify-content: center;\r\n\t\t}\r\n\t\t</style>\r\n\t</head>\r\n\t<body>\r\n\t\t<p class=\"main-title\">Avalon Avatar Archive</p>\r\n\t\t<p class=\"site-name\">ProAvalon</p>\r\n\t\t<div class=\"players\">");
for (int i = 0; i < lines.Length; i++)
{
    if (!lines[i].StartsWith(username))
    {
        if (i != 0)
            sb.Append("\t\t\t\t</div>\r\n\t\t\t</div>\n");
        username = lines[i].Substring(0, lines[i].IndexOf('-'));
        sb.Append($"\t\t\t<div class=\"player\">\r\n\t\t\t\t<div class=\"player-name\">{username}</div>\r\n\t\t\t\t<div class=\"player-icons\">\n");
        sb.Append($"\t\t\t\t\t<img src=\"PROAVALON/{lines[i]}\"></img>\n");
    }
    else
    {
        sb.Append($"\t\t\t\t\t<img src=\"PROAVALON/{lines[i]}\"></img>\n");
    }
}
sb.Append("\t\t</div>\r\n\t</body>\r\n</html>");

File.WriteAllText(outputPath, sb.ToString());