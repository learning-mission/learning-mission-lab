using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class SocialNetwork
    {
        string _linkedin;
        string _github;
        string _facebook;
        string _otherLink;

        public SocialNetwork() {}
        public SocialNetwork(string linkedin, string github, string facebook)
        {
            this.Linkedin = linkedin;
            this.Github = github;
            this.Facebook = facebook;
        }
        public SocialNetwork(string linkedin, string github, string facebook, string otherLink)
        {
            this.Linkedin = linkedin;
            this.Github = github;
            this.Facebook = facebook;
            this.OtherLink = otherLink;
        }

        public string Linkedin { get => _linkedin; set => _linkedin = value; }
        public string Github { get => _github; set => _github = value; }
        public string Facebook { get => _facebook; set => _facebook = value; }
        public string OtherLink { get => _otherLink; set => _otherLink = value; }
    }
}
