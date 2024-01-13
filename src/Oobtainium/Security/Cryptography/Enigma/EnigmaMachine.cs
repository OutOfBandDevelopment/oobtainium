using System;
using System.Collections.Generic;
using System.Linq;

namespace OoBDev.Oobtainium.Security.Cryptography.Enigma;

// https://en.wikipedia.org/wiki/Enigma_rotor_details
// http://enigmaco.de/enigma/enigma.html
public class EnigmaMachine
{
    private string[]? plugboard;
    private int[]? postions;
    private int[]? ringSettings;
    private readonly EnigmaRotor[] rotors;
    private readonly EnigmaReflector reflector;

    public EnigmaMachine(EnigmaRotor[] rotors,
                         EnigmaReflector reflector,
                         //string start = null, 
                         string? ringSettings = default,
                         string? plugBoard = default)
    {
        if (rotors == null || rotors.Length < 3 || rotors.Length > 5)
            throw new InvalidOperationException("Invalid Rotor Set");

        this.rotors = rotors.Reverse().ToArray();
        this.reflector = reflector ?? throw new InvalidOperationException("Invalid Reflector");
        //this.Positions = default;  //(start ?? new string('A', rotors.Length));
        RingSettings = ringSettings;
        PlugBoard = plugBoard;
    }

    public string Positions
    {
        get
        {
            return (postions?
                        .Reverse()
                        .Select(p => (char)(p + 'A'))
                        .AsString()
                        + new string('A', rotors.Length)
                        )[..rotors.Length];
        }
        set
        {
            postions = (value ?? new string('A', rotors.Length)).Select(i => i - 'A')
                                 .Concat(new int[rotors.Length])
                                 .Take(rotors.Length)
                                 .Reverse()
                                 .ToArray();
        }
    }

    public string? RingSettings
    {
        get
        {
            return (ringSettings?
                        .Reverse()
                        .Select(p => (char)(p + 'A'))
                        .AsString()
                        + new string('A', rotors.Length)
                        )[..rotors.Length];
        }
        private set
        {
            ringSettings = (value ?? new string('A', rotors.Length)).Select(i => i - 'A')
                                     .Concat(new int[rotors.Length])
                                     .Take(rotors.Length)
                                     .Reverse()
                                     .ToArray();
        }
    }

    public string? PlugBoard
    {
        get
        {
            return string.Join(" ", plugboard ?? []);
        }
        set
        {
            var cleaned = value?.Clean().AsString() ?? "";
            if (cleaned.Length % 2 == 0 && cleaned.GroupBy(c => c).Any(c => c.Count() != 1))
                throw new InvalidOperationException("Invalid Plug Board");

            plugboard = cleaned?.SplitAt(2).ToArray();
        }
    }

    public string Rotors
    {
        get { return string.Join(";", rotors.Select(r => r.Number)); }
    }
    public string Reflector
    {
        get { return reflector.Number; }
    }

    public string Process(string input)
    {
        input = input.Clean().AsString().SwapSet(plugboard);
        var start = Positions;
        var set = rotors;
        var rs = ringSettings ??
                throw new ApplicationException($"{nameof(ringSettings)} not set");

        var l = 26; // set[0].Length;

        var cOut = new List<char>();

        foreach (var c in input.Select(x => x - 'A'))
        {
            if (postions == null)
                throw new ApplicationException($"{nameof(postions)} not set");
            postions[0] = (postions[0] + 1) % l;
            if (rotors[0].RotateOn.Contains((char)(postions[0] + 'A')))
            {
                postions[1] = (postions[1] + 1) % l;

                if (rotors[1].RotateOn.Contains((char)(postions[1] + 'A')))
                {
                    postions[2] = (postions[2] + 1) % l;

                    if (rotors.Length > 3 &&
                        rotors[2].RotateOn.Contains((char)(postions[2] + 'A')))
                    {
                        postions[3] = (postions[3] + 1) % l;
                    }
                }
            }

            var indexes = postions;

            var m = c;
            for (var i = 0; i < set.Length; i++)
                m = (set[i].Wiring[(m + indexes[i] + rs[i]) % l] - indexes[i] - 'A' + l) % l;
            m = (reflector.Wiring[m] - 'A' + l) % l;
            for (var i = set.Length - 1; i > -1; i--)
                m = (set[i].Wiring.IndexOf((char)((m + indexes[i]) % l + 'A')) - indexes[i] - rs[i] + l) % l;
            cOut.Add((char)(m + 'A'));
        }
        return cOut.AsString().SwapSet(plugboard);
    }
}
