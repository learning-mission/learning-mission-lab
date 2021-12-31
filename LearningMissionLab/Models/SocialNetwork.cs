using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class SocialNetwork
    {
        Network _networkName;
        string _networkLink;

        public SocialNetwork() {}
        public SocialNetwork(Network networkName, string networkLink)
        {
            this.NetworkName = networkName;
            this.NetworkLink = networkLink;
        }

        public Network NetworkName { get => _networkName; set => _networkName = value; }
        public string NetworkLink { get => _networkLink; set => _networkLink = value; }
    }
}
