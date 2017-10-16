using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);         
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You go to play " + directionNoun);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("You head over to the arcade cabinet titled " + directionNoun + ". You're surprised to find that it actually has a video game version of " + directionNoun + ". Which is as terrible as it sounds.");
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}
