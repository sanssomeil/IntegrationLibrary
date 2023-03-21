using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace IntegrationLibrary
{
    public class ParticipantFactory
    {
    	private DateTime? date = null;
        private JsonDocument xxxxData = null;
        
        public ParticipantFactory(DateTime date)
        {
            this.date = date;
        }

        public Participant getFromyyByMainId (string mainId)
        {
            Participant participant = null;
            try
            {
                this.loadxxxxDataOnce();
                JsonElement root = xxxxData.RootElement;
                foreach (JsonElement xxx in root.GetProperty("XXXXXX").EnumerateArray())
                {
                    foreach (JsonElement yyy in xxx.GetProperty("YYYYYY").EnumerateArray())
                    {
                        string id = yyy.GetProperty("main_id").GetString();
                        if ((mainId == id && mainId.Length == 8) || (id.Length != 0 && mainId == id.Substring(3)))
                        {
                            if (participant == null)
                            {
                                participant = new Participant();
                            }
                            participant.id1 = xxx.GetProperty("id_1").GetInt32().ToString();
                            participant.id3 = yyy.GetProperty("id_3").GetInt32().ToString();
                            participant.listIds0.Add(yyy.GetProperty("Ids_0").GetString());
                            participant.listIds1.Add(yyy.GetProperty("Ids_1").GetString());
                            foreach (JsonElement element in yyy.GetProperty("yy_Info_1").EnumerateArray())
                            {
                                if (participant.yyInfo1.ContainsKey(element.GetProperty("yy_Info_1_Keys").GetString()) == false)
                                {
                                    participant.yyInfo1[element.GetProperty("yy_Info_1_Keys").GetString()] = new List<string>();
                                }
                                participant.yyInfo1[element.GetProperty("yy_Info_1_Keys").GetString()].Add(element.GetProperty("item").GetString());
                            }
                            foreach (JsonElement element in yyy.GetProperty("yy_Info_2").EnumerateArray())
                            {
                                if (element.GetProperty("is_it").GetBoolean() == true)
                                {
                                    if (participant.yyInfo3.ContainsKey(element.GetProperty("yy_Info_3_Keys").GetString()) == false)
                                    {
                                        participant.yyInfo3[element.GetProperty("yy_Info_3_Keys").GetString()] = new List<string>();
                                    }
                                    participant.yyInfo3[element.GetProperty("yy_Info_3_Keys").GetString()].Add(element.GetProperty("item").GetString();
                                }
                                else
                                {
                                    if (participant.yyInfo2.ContainsKey(element.GetProperty("yy_Info_2_Keys").GetString()) == false)
                                    {
                                        participant.yyInfo2[element.GetProperty("yy_Info_2_Keys").GetString()] = new List<string>();
                                    }
                                    participant.yyInfo2[element.GetProperty("yy_Info_2_Keys").GetString()].Add(element.GetProperty("item").GetString();
                                }
                            }
                            foreach (JsonElement p in root.GetProperty("Participants").EnumerateArray())
                            {
                                string id1 = p.GetProperty("id_1").GetInt32().ToString();
                                if (participant.id1 == id1)
                                {
                                    participant.id2 = p.GetProperty("id2").GetString();
                                    participant.name = p.GetProperty("name").GetString();
                                }
                            }                        
                        }
                    }
                }
            }
            catch(Exception e) {
                Utils.processException(e);
            }
            return participant;
        }

        public List<Participant> getFromxxByMainId (string mainId)
        {
            List<Participant> participants = new List<Participant>();
            try
            {
                this.loadxxxxDataOnce();
                List<string> xxInfo1 = new List<string>();
                List<string> xxInfo2 = new List<string>();
                List<string> xxInfo3 = new List<string>();
                JsonElement root = xxxxData.RootElement;
                
                foreach (JsonElement xxx in root.GetProperty("XXXXXX").EnumerateArray())
                {
                    Participant participant = null;
                    
                    foreach (JsonElement yyy in xxx.GetProperty("YYYYYY").EnumerateArray())
                    {
                        string id = yyy.GetProperty("main_id").GetString();
                        
                        if ((mainId == id && mainId.Length == 11) || (id.Length != 0 && mainId == id.Substring(6)))
                        {
                            if (participant == null)
                            {
                                participant = new Participant();
                                string id1 = xxx.GetProperty("bank_id").GetInt32().ToString();
                                
                                foreach (JsonElement eachParticipant in root.GetProperty("Participants").EnumerateArray())
                                {
                                    if (bank_id == eachParticipant.GetProperty("id_1").GetInt32().ToString())
                                    {
                                        participant.id1 = eachParticipant.GetProperty("id_1").GetInt32().ToString();
                                        participant.name = eachParticipant.GetProperty("name").GetString();
                                        participant.id2 = eachParticipant.GetProperty("id_2").GetString();
                                        participant.xxInfo1 = xxInfo1;
                                        participant.xxInfo2 = xxInfo2;
                                        participant.xxInfo3 = xxInfo3;
                                        participants.Add(participant);
                                        break;
                                    }
                                }
                            }
                            
                            participant.mainId = mainId;
                            participant.id3 = yyy.GetProperty("id_3").GetInt32().ToString();                            
                            participant.listIds0.Add (yyy.GetProperty("Ids_0").GetString());
                            participant.listIds1.Add (yyy.GetProperty("Ids_1").GetString());
                            
                            foreach (JsonElement element in yyy.GetProperty("xx_Info_1").EnumerateArray())
                            {
                                xxInfo1.Add (element.GetProperty("item").GetString());
                            }

                            foreach (JsonElement element in yyy.GetProperty("xx_Info_2").EnumerateArray())
                            {
                                if (element.GetProperty("is_it").GetBoolean() == true)
                                {
                                    xxInfo3.Add (element.GetProperty("item").GetString();
                                }
                                else
                                {
                                    xxInfo2.Add (element.GetProperty("item").GetString();
                                }
                            }
                        }
                    }
                }                
            }
            catch (Exception e)
            {
                Utils.processException(e);
            }
            return participants;
        }

        private void loadxxxxDataOnce()
        {
            if (xxxxData == null)
            {
                xxxxData = (new Fetcher()).loadDataByDate(date);
            }
        }
    }
}
