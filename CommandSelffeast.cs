using System;
using System.Collections;
using System.Collections.Generic;

using Rocket.API;
using Rocket.Unturned.Chat;
using UnityEngine;
using Rocket.Unturned.Player;

namespace ZaupFeast
{
    public class CommandSelfFeast : IRocketCommand
    {
        public string Name
        {
            get { return "selffeast"; }
        }
        public string Help
        {
            get { return "Starts the feast onto the player"; }
        }
        public string Syntax
        {
            get { return ""; }
        }
        public List<string> Aliases
        {
            get { return new List<string> { "sfeast" }; }
        }
        public List<string> Permissions
        {
            get { return new List<string>(); }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Both;
            }
        }

        // Run the command.
        public void Execute(IRocketPlayer caller, string[] command)
        {
            Locs loc = new Locs(((UnturnedPlayer)caller).Position, ((UnturnedPlayer)caller).DisplayName + "'s pos");
            Feast.Instance.nextLocation = loc;
            UnturnedChat.Say(Feast.Instance.Translate("now_feast_msg", new object[] {
                Feast.Instance.nextLocation.Name
                }), UnturnedChat.GetColorFromName(Feast.Instance.Configuration.Instance.MessageColor, Color.red));
            Feast.Instance.runFeast();
        }
    }
}
