using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewProblem
{
    public class TripVmController
    {

        public DateTime startTime;
        public DateTime endTime;
        public List<TripSetting> tripSettings;
        public List<TripUploadData> tripUploadData;
        public List<TripUploadEvent> tripUploadEvents;

        public TripVmController(TripVm tripVm)
        {
            if (tripVm.tripSettings != null)
            {
                tripSettings = tripVm.tripSettings.ToList();
            }

            if (tripVm.tripUploadData != null)
            {
                tripUploadData = tripVm.tripUploadData.ToList();
            }

            if (tripVm.tripUploadEvents!= null)
            {
                tripUploadEvents = tripVm.tripUploadEvents.ToList();
            }

            if(tripVm.startTime != null)
            {
                startTime = tripVm.startTime;
            }

            if (tripVm.endTime != null)
            {
                endTime = tripVm.endTime;
            }
        }

        /// <summary>
        /// Returns a List of List of TripUploadEvents that has been separated by Channel.
        /// </summary>
        public List<List<TripUploadEvent>> SeperateEventListByChannel(List<TripUploadEvent> unsortedList)
        {
            return unsortedList.GroupBy(x => x.channel).Select(x => x.ToList()).ToList();
        }

        /// <summary>
        /// Returns a List of TripUploadEvents ordered by timestamp (ascending).
        /// </summary>
        public List<TripUploadEvent> OrderEventListByTimeStamp(List<TripUploadEvent> unsortedList)
        {
            List<TripUploadEvent> sortedList = unsortedList.OrderBy(x => x.timestamp).ToList();

            return sortedList;
        }

        /// <summary>
        /// Returns a List of AlarmEventPairs that are combined from the TripUploadEventList
        /// </summary>
        public List<AlarmEventPair> GetAlarmEventPairFromEventsList(List<TripUploadEvent> orderedTripUploadEventList)
        {
            List<AlarmEventPair> alarmEventPairList = new List<AlarmEventPair>();

            AlarmEventPair tempAlarmEventPair = new AlarmEventPair();

            if (orderedTripUploadEventList != null)
            {
                foreach (TripUploadEvent tripUploadEvent in orderedTripUploadEventList)
                {
                    if ((tripUploadEvent.eventType == (int)AlarmState.MaxAlarmOut) || (tripUploadEvent.eventType == (int)AlarmState.MinAlarmOut))
                    {
                        tempAlarmEventPair.OutEvent = tripUploadEvent;
                    }

                    if ((tripUploadEvent.eventType == (int)AlarmState.MaxAlarmIn) || (tripUploadEvent.eventType == (int)AlarmState.MinAlarmIn))
                    {
                        tempAlarmEventPair.InEvent = tripUploadEvent;
                        alarmEventPairList.Add(tempAlarmEventPair);
                        tempAlarmEventPair = new AlarmEventPair();
                    }
                }
            }

            return alarmEventPairList;
        }

        /// <summary>
        /// Returns an integer of seconds of total duration of all given events.
        /// </summary>
        public int GetDurationOfAllEvents(List<AlarmEventPair> alarmEventPairs)
        {
            foreach (AlarmEventPair pairs in alarmEventPairs)
            {
                if(!pairs.HasInEvent())
                {
                    pairs.InEvent = new TripUploadEvent();
                    pairs.InEvent.timestamp = endTime;
                }
            }

            return alarmEventPairs.Sum(x => x.GetDuration());
        }

        public List<List<TripUploadData>> SeperateDataListByChannel(List<TripUploadData> unsortedList)
        {
            return unsortedList.GroupBy(x => x.channel).Select(x => x.ToList()).ToList();
        }

        /// <summary>
        /// Returns a List of TripUploadData ordered by timestamp (ascending).
        /// </summary>
        public List<TripUploadData> OrderDataListByTimeStamp(List<TripUploadData> unsortedList)
        {
            List<TripUploadData> sortedList = unsortedList.OrderBy(x => x.timestamp).ToList();

            return sortedList;
        }

        /// <summary>
        /// Displays total duration for each channel from the event data.
        /// </summary>
        public void ShowEventDurationData()
        {
            foreach (List<TripUploadEvent> tripUploadEventList in SeperateEventListByChannel(tripUploadEvents))
            {
                string channelName = tripUploadEventList.Select(x => x.channel).First();
                Console.WriteLine(channelName + " in alarm from events for {0} seconds.", GetDurationOfAllEvents(GetAlarmEventPairFromEventsList(OrderEventListByTimeStamp(tripUploadEventList))));
            }
        }

        /// <summary>
        /// Returns a list of AlarmEventPair that are combined from the TripUploadData list.
        /// </summary>
        public List<AlarmEventPair> GetDataAsAlarmEventPair(TripSetting tripSetting, List<TripUploadData> sortedTripUploadDataList)
        {
            List<AlarmEventPair> dataAsAlarmEventPair = new List<AlarmEventPair>();

            AlarmEventPair tempAlarmEventPair = new AlarmEventPair();

            if (tripSetting != null && sortedTripUploadDataList != null)
            {
                for (int index = 0; index < sortedTripUploadDataList.Count; index++)
                {
                    if (sortedTripUploadDataList[index].channel == tripSetting.channelName)
                    {
                        if (sortedTripUploadDataList[index].data > tripSetting.max)
                        {
                            tempAlarmEventPair.OutEvent = new TripUploadEvent(sortedTripUploadDataList[index].accountId, sortedTripUploadDataList[index].serialNumber, sortedTripUploadDataList[index].channel, (int)AlarmState.MaxAlarmOut, sortedTripUploadDataList[index].timestamp, sortedTripUploadDataList[index].data.ToString(), null, null, null, null, sortedTripUploadDataList[index].id, sortedTripUploadDataList[index].createdAt, sortedTripUploadDataList[index].createdBy, sortedTripUploadDataList[index].modifiedAt, sortedTripUploadDataList[index].modifiedBy);
                            tempAlarmEventPair.InEvent = new TripUploadEvent(sortedTripUploadDataList[index + 1].accountId, sortedTripUploadDataList[index + 1].serialNumber, sortedTripUploadDataList[index + 1].channel, (int)AlarmState.MaxAlarmIn, sortedTripUploadDataList[index + 1].timestamp, sortedTripUploadDataList[index + 1].data.ToString(), null, null, null, null, sortedTripUploadDataList[index + 1].id, sortedTripUploadDataList[index + 1].createdAt, sortedTripUploadDataList[index + 1].createdBy, sortedTripUploadDataList[index + 1].modifiedAt, sortedTripUploadDataList[index + 1].modifiedBy);
                            dataAsAlarmEventPair.Add(tempAlarmEventPair);
                            tempAlarmEventPair = new AlarmEventPair();
                            index++;
                        }
                        else if (sortedTripUploadDataList[index].data < tripSetting.min)
                        {
                            tempAlarmEventPair.OutEvent = new TripUploadEvent(sortedTripUploadDataList[index].accountId, sortedTripUploadDataList[index].serialNumber, sortedTripUploadDataList[index].channel, (int)AlarmState.MaxAlarmOut, sortedTripUploadDataList[index].timestamp, sortedTripUploadDataList[index].data.ToString(), null, null, null, null, sortedTripUploadDataList[index].id, sortedTripUploadDataList[index].createdAt, sortedTripUploadDataList[index].createdBy, sortedTripUploadDataList[index].modifiedAt, sortedTripUploadDataList[index].modifiedBy);
                            tempAlarmEventPair.InEvent = new TripUploadEvent(sortedTripUploadDataList[index + 1].accountId, sortedTripUploadDataList[index + 1].serialNumber, sortedTripUploadDataList[index + 1].channel, (int)AlarmState.MinAlarmIn, sortedTripUploadDataList[index + 1].timestamp, sortedTripUploadDataList[index + 1].data.ToString(), null, null, null, null, sortedTripUploadDataList[index + 1].id, sortedTripUploadDataList[index + 1].createdAt, sortedTripUploadDataList[index + 1].createdBy, sortedTripUploadDataList[index + 1].modifiedAt, sortedTripUploadDataList[index + 1].modifiedBy);
                            dataAsAlarmEventPair.Add(tempAlarmEventPair);
                            tempAlarmEventPair = new AlarmEventPair();
                            index++;
                        }
                    }
                }
            }

            return dataAsAlarmEventPair;
        }

        /// <summary>
        /// Displays total duration for each channel from the wrapped data.
        /// </summary>
        public void ShowDataWrappedDurationData()
        {
            foreach (List<TripUploadData> tripUploadDataList in SeperateDataListByChannel(tripUploadData))
            {
                
                foreach (TripSetting tripSetting in tripSettings)
                {
                    if (tripUploadDataList.Select(x => x.channel == tripSetting.channelName).First())
                    {
                        Console.WriteLine(tripSetting.channelName + " in alarm from wrapped data for {0} seconds.", GetDurationOfAllEvents(GetDataAsAlarmEventPair(tripSetting, OrderDataListByTimeStamp(tripUploadDataList))));
                    }
                }
            }
        }

    }
}
