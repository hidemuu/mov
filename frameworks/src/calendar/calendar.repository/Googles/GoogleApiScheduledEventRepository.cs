﻿using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Mov.Calendar.Models.Entities;
using Mov.Calendar.Repository.Googles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Calendar.Repository.Google
{
    public class GoogleApiScheduledEventRepository
    {
        public async Task<TaskContent[]> FetchScheduledEventsAsync(string[] targetKinds, DateTime from, DateTime to)
        {
            // アクセストークン取得
            var credential = await CredentialProvider.GetUserCredentialAsync();
            if (credential == null)
                return new TaskContent[0];

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "TaskRecorder",
            });

            // Define parameters of request.
            var request = service.Events.List("primary");
            request.TimeMin = from;
            request.TimeMax = to;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            var events = await request.ExecuteAsync();
            if (events.Items == null)
                return new TaskContent[0];

            var list = new List<TaskContent>(events.Items.Count);
            foreach (var eventItem in events.Items)
            {
                // 時間未定のイベントは無視する
                if (string.IsNullOrEmpty(eventItem.Start.Date) == false)
                    continue;

                // 指定された種別以外は無視する
                var kind = eventItem.GetScheduleKind() ?? "";
                if (targetKinds.Any()
                        && targetKinds.Contains(kind) == false)
                    continue;

                // 開始時間=終了時間のイベントは無視する
                if (eventItem.Start.DateTime.HasValue
                    && eventItem.End.DateTime.HasValue
                    && eventItem.Start.DateTime == eventItem.End.DateTime)
                    continue;

                var scheduledEvent = new TaskContent
                {
                    Id = eventItem.Id,
                    Kind = kind,
                    Source = "GoogleCalendar",
                    Title = eventItem.Summary,
                    Remarks = eventItem.Description,
                    StartTime = eventItem.Start.DateTime.Value,
                    EndTime = eventItem.End.DateTime.Value,
                };

                list.Add(scheduledEvent);
            }

            return list.ToArray();
        }

    }

    public static class GoogleEventExtensions
    {
        public static string GetScheduleKind(this Event @event)
        {
            if (@event.ExtendedProperties == null)
                return "";

            @event.ExtendedProperties.Shared.TryGetValue("eventType", out string result);
            return result;
        }
    }
}
