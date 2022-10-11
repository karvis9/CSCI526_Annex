// (c) Copyright 2021 HP Development Company, L.P.

using System.Collections;
using HP.Omnicept.Unity;
using System.Collections.Generic;
using HP.Omnicept.Messaging.Messages;
using UnityEngine;
using UnityEngine.UI;


namespace HP.Omnicept.Unity.Examples.SetSubscription
{
    public class SubscriptionSetter : MonoBehaviour
    {
        private static SubscriptionList m_cogLoadLatestSub = new SubscriptionList();
        private static SubscriptionList m_cogLoad1p0Sub = new SubscriptionList();
        private static SubscriptionList m_cogLoad1p1Sub = new SubscriptionList();

        private Dictionary<string, SubscriptionList> m_cogLoadVerOptions = new Dictionary<string, SubscriptionList>
                                {
                                    {"Latest", m_cogLoadLatestSub},
                                    {"Cognitive Load 1.0.0", m_cogLoad1p0Sub },
                                    {"Cognitive Load 1.1.0", m_cogLoad1p1Sub },
                                    {"None", new SubscriptionList()}
                                }; //add other values as needed
        public GliaBehaviour Glia;
        public Dropdown ClVersionDropdown;
        void Start()
        {
            m_cogLoadLatestSub.Subscriptions.Add(new Subscription(MessageTypes.ABI_MESSAGE_COGNITIVE_LOAD, "", "", "", "", new MessageVersionSemantic("")));
            m_cogLoad1p0Sub.Subscriptions.Add(new Subscription(MessageTypes.ABI_MESSAGE_COGNITIVE_LOAD, "", "", "", "", new MessageVersionSemantic("1.0.0")));
            m_cogLoad1p1Sub.Subscriptions.Add(new Subscription(MessageTypes.ABI_MESSAGE_COGNITIVE_LOAD, "", "", "", "", new MessageVersionSemantic("1.1.0")));
            if (Glia == null)
            {
                Debug.LogError("Requires Glia to be not null");
            }
            if(ClVersionDropdown != null)
            {
                ClVersionDropdown.ClearOptions();
                List<string> versionOptions = new List<string>();
                foreach(var key in m_cogLoadVerOptions.Keys)
                {
                    versionOptions.Add(key);
                }
                ClVersionDropdown.AddOptions(versionOptions);
                ClVersionDropdown.onValueChanged.AddListener(delegate{CogLoadVersionChanged(ClVersionDropdown);});
                ClVersionDropdown.RefreshShownValue();
            }
            else
            {
                Debug.LogError("Requires Dropdown component to work");
            }

        }

        public void CogLoadVersionChanged(Dropdown dd)
        {
            if(Glia != null)
            {
                Debug.Log("Setting subscription to " + dd.options[dd.value].text);
                Glia.SetSubscriptions(m_cogLoadVerOptions[dd.options[dd.value].text]);
            }
            else
            {
                Debug.LogError("Glia has not been set");
            }
        }
    }
}
