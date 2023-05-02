using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracks : MonoBehaviour
{
    public struct Drums
    {
        public static bool Kick(int midiNote)
        {
            switch(midiNote)
            {
                case 35:
                case 36:
                    return true;
                default:
                    return false;
            }
        }

        public static bool Snare(int midiNote)
        {
            switch(midiNote)
            {
                case 33: //sidestick
                case 37: //sidestick
                case 40: //esnare
                case 38: //snare
                case 91: //rimshot
                    return true;
                default:
                    return false;
            }
        }

        public static bool Tom0(int midiNote)
        {
            switch (midiNote)
            {
                case 48:
                    return true;
                default:
                    return false;
            }
        }

        public static bool Tom1(int midiNote)
        {
            switch (midiNote)
            {
                case 47: //low mid
                case 48: //hi mid
                case 50: //high tom
                case 60: //hi bongo
                    return true;
                default:
                    return false;
            }
        }

        public static bool Tom2(int midiNote)
        {
            switch (midiNote)
            {
                case 45: //mid tom
                case 61: //low bongo
                    return true;
                default:
                    return false;
            }
        }

        public static bool Tom3(int midiNote)
        {
            switch (midiNote)
            {
                case 41: //low floor tom
                case 43: //floor tom
                    return true;
                default:
                    return false;
            }
        }


        public static bool LeftCrash(int midiNote)
        {
            switch (midiNote)
            {
                case 55: //splash
                case 95: //choked splash
                case 57: //left crash
                case 98: //choked left crash
                    return true;
                default:
                    return false;
            }
        }

        public static bool RightCrash(int midiNote)
        {
            switch (midiNote)
            {
                case 49: //right crash
                case 97: //choked right crash
                    return true;
                default:
                    return false;
            }
        }

        public static bool China(int midiNote)
        {
            switch (midiNote)
            {
                case 52: //china
                case 96: //choked china
                    return true;
                default:
                    return false;
            }
        }

        public static bool Hihat(int midiNote)
        {
            switch (midiNote)
            {
                case 42: //hihat closed
                case 44: //hihat pedal chink
                case 46: //hihat open
                case 92: //hihat half open
                    return true;
                default:
                    return false;
            }
        }

        public static bool Ride(int midiNote)
        {
            switch(midiNote)
            {
                case 51: //ride tip
                case 53: //ride bell
                case 59: //ride 2
                case 93: //ride crash
                    return true;
                default:
                    return false;
            }
        }
    }

    public struct Click
    {
        public static int halfIntroChorus { get { return 240; } }
        public static int endIntroChorus { get { return 0; } }
    }
}
