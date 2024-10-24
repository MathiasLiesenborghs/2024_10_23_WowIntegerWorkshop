
using NAudio.Midi;
using System;

public class ListenToMidi
{

    public MidiIn midiIn;

    public ListenToMidi()
    {
        // Chercher dans package console de visual studio et copier:
        //NuGet\Install-Package NAudio -Version 2.2.1


        // Liste les dispositifs MIDI connectés
        int deviceCount = MidiIn.NumberOfDevices;
        Console.WriteLine("Dispositifs MIDI trouvés : " + deviceCount);

        for (int i = 0; i < deviceCount; i++)
        {
            Console.WriteLine($"Device {i}: {MidiIn.DeviceInfo(i).ProductName}");
        }

        if (deviceCount > 0)
        {
            // Ouvrir le premier dispositif MIDI
            midiIn = new MidiIn(0); // 0 signifie le premier dispositif, modifiable si tu veux un autre

            // Gestionnaire d'événements MIDI
            midiIn.MessageReceived += MidiIn_MessageReceived;

            // Commence à écouter le dispositif MIDI
            midiIn.Start();

           

        }
        else
        {
            Console.WriteLine("Aucun dispositif MIDI trouvé.");
        }
    }

     ~ListenToMidi() {

        if (midiIn != null) {

            midiIn.Stop();
            midiIn.Dispose();
        }
    }

    // Méthode appelée quand un message MIDI est reçu
    private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
    {
        //Console.WriteLine($"Message reçu: {e.MidiEvent}"); // Affiche les messages MIDI

        if (e.MidiEvent is MidiEvent midiEvent) {

            if (midiEvent is NoteOnEvent noteOn) {
                if (m_onKeyReceived != null) {
                    if (noteOn.Velocity > 0)
                        m_onKeyReceived.Invoke(noteOn.NoteNumber, true);
                    else {
                        m_onKeyReceived.Invoke(noteOn.NoteNumber, false);
                    }
                }
            }
            else if(midiEvent is NoteEvent noteOff) {
                if (m_onKeyReceived != null)
                {
                        m_onKeyReceived.Invoke(noteOff.NoteNumber, false);
                    
                }
            }
        }
    }

    Action<int, bool> m_onKeyReceived;
    public void AddUpDownListener(Action<int, bool> midiNoteDetected)
    {
        m_onKeyReceived = midiNoteDetected;
    }
}

