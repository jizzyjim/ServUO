using Server;
using System;

namespace Server.Items
{
    public class EpauletteBearingTheCrestOfBlackthorn3 : Cloak
    {
        public override bool IsArtifact { get { return true; } }

        public override int LabelNumber { get { return 1123325; } } // Epaulette

        [Constructable]
        public EpauletteBearingTheCrestOfBlackthorn3()
        {
            ReforgedSuffix = ReforgedSuffix.Blackthorn;
            ItemID = 0x9985;
            SkillBonuses.SetValues(0, SkillName.Stealth, 10.0);
            Hue = 2130;

            Layer = Layer.OuterTorso;
        }

        public override int InitMinHits { get { return 255; } }
        public override int InitMaxHits { get { return 255; } }       

        public EpauletteBearingTheCrestOfBlackthorn3(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            if (Layer != Layer.OuterTorso)
            {
                if (Parent is Mobile)
                {
                    ((Mobile)Parent).AddToBackpack(this);
                }

                Layer = Layer.OuterTorso;
            }
        }
    }
}