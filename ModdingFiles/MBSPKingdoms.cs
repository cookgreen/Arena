﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArenaModdingTool.ModdingFiles
{
    [XmlRoot("Kingdoms")]
    public class MBSPKingdoms
    {
        [XmlElement("Kingdom")]
        public List<MBSPKingdom> Kingdoms { get; set; }
    }

    [XmlRoot("Kingdom")]
    public class MBSPKingdom
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string owner { get; set; }
        [XmlAttribute]
        public string banner_key { get; set; }
        [XmlAttribute]
        public string primary_banner_color { get; set; }
        [XmlAttribute]
        public string secondary_banner_color { get; set; }
        [XmlAttribute]
        public string label_color { get; set; }
        [XmlAttribute]
        public string color { get; set; }
        [XmlAttribute]
        public string color2 { get; set; }
        [XmlAttribute]
        public string alternative_color { get; set; }
        [XmlAttribute]
        public string alternative_color2 { get; set; }
        [XmlAttribute]
        public string culture { get; set; }
        [XmlAttribute]
        public string settlement_banner_mesh { get; set; }
        [XmlAttribute]
        public string flag_mesh { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string short_name { get; set; }
        [XmlAttribute]
        public string title { get; set; }
        [XmlAttribute]
        public string ruler_title { get; set; }
        [XmlAttribute]
        public string text { get; set; }

        [XmlArray("relationships")]
        [XmlArrayItem("relationship")]
        public List<KingdomRelationship> Relationships { get; set; }

        [XmlArray("policies")]
        [XmlArrayItem("policy")]
        public List<KingdomPolicy> Policies { get; set; }
    }
    public class KingdomRelationship
    {
        [XmlAttribute]
        public string kingdom { get; set; }
        [XmlAttribute]
        public string value { get; set; }
        [XmlAttribute]
        public string isAtWar { get; set; }
    }

    public class KingdomPolicy
    {
        [XmlAttribute]
        public string id { get; set; }
    }
}