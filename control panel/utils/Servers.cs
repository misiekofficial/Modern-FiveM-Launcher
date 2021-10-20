using control_panel;
using System.Collections;

namespace control_panel
{
    public static class Servers
    {
        static public ArrayList LoadListBoxData()
        {
            ArrayList itemsList = new ArrayList();
            itemsList.Add(new ServerComponents() { NazwaSerwera = "Exile Roleplay WL-ON", Ikona = "logo.png", DiscordLink = "28u3p2vBjE", IP = "exilerp.eu" });
            itemsList.Add(new ServerComponents() { NazwaSerwera = "Sativa Roleplay", Ikona = "logo.png", DiscordLink = "sativarp", IP = "sativarp.pl" });
            itemsList.Add(new ServerComponents() { NazwaSerwera = "Neon Roleplay", Ikona = "logo.png", DiscordLink = "neonrp", IP = "ls.neonrp.pl" });
            itemsList.Add(new ServerComponents() { NazwaSerwera = "Coco Roleplay WL-OFF", Ikona = "logo.png", DiscordLink = "cocorp", IP = "wloff.cocorp.pl" });
            itemsList.Add(new ServerComponents() { NazwaSerwera = "Realm Roleplay WL-OFF", Ikona = "logo.png", DiscordLink = "realmroleplay", IP = "off.realmrp.pl" });
            return itemsList;
        }
    }
}
