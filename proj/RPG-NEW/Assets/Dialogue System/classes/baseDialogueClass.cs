using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace Project.DialogueSystem
{
    public class baseDialogueClass : MonoBehaviour, IDSdialogue
    {

        int i;

        public bool openDialogue = false;

        [SerializeField]
        string[] _dialogue;

        [SerializeField]
        GameObject _objTrigger;

        public GameObject _holder;

        public Text _dialogueBox;

        public string[] Dialogue
        {
            get
            {
                return _dialogue;
            }

            set
            {
                _dialogue = value;
            }
        }

        public GameObject objectTrigger
        {
            get
            {
                return _objTrigger;
            }

            set
            {
                _objTrigger = value;
            }
        }



        // Use this for initialization
        void Start()
        {
            _dialogueBox.text = "";
            i = 0;
            openDialogue = false;
        }


       

        // Update is called once per frame
        void Update()
        {
            _holder.SetActive(openDialogue);
            if (Input.GetMouseButtonDown(1))
            {
                openDialogue = true;
            }

            if (openDialogue)
            {
                if (i == 0)
                {
                    _dialogueBox.text = _dialogue[i];
                    i++;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    if (!(i == Dialogue.Length + 1))
                    {
                        if (i < Dialogue.Length)
                        {
                            _dialogueBox.text = _dialogue[i];
                            i++;
                        }
                        else
                        {
                            _dialogueBox.text = "";
                            i = 0;
                            openDialogue = false;
                        }
    
                    }
  
                }
            } 
        }
    }
}