using System;
namespace Zendesk.Ticket.Viewer.Service
{
    public static class GetTicketsResponseTranslator
    {
        public static GetTicketResponse ToGetTicketsDataContract(this Domain.Ticket tickets)
        {
            if (tickets == null)
                return null;

            var ticketResponse = new GetTicketResponse()
            {
                URL = tickets.URL,
                Id = tickets.Id,
                ExternalId = tickets.ExternalId,
                Description = tickets.Description,
                CreatedAt = tickets.CreatedAt,
                UpdatedAt = tickets.UpdatedAt,
                Type = tickets.Type,
                Subject = tickets.Subject,
                RawSubject = tickets.RawSubject,
                Priority = tickets.RawSubject,
                Status = tickets.Status,
                Recipient = tickets.Recipient,
                RequesterId = tickets.RequesterId,
                SubmitterId = tickets.SubmitterId,
                AssigneeId = tickets.AssigneeId,
                OrganizationId = tickets.OrganizationId,
                GroupId = tickets.GroupId,
                ForumTopicId = tickets.ForumTopicId,
                ProblemId = tickets.ProblemId,
                HasIncidents = tickets.HasIncidents,
                IsPublic = tickets.IsPublic,
                DueAt = tickets.DueAt,
                SatisfactionRating = tickets.SatisfactionRating,
                TicketFormId = tickets.TicketFormId,
                BrandId = tickets.BrandId,
                AllowChannelBack = tickets.AllowChannelBack,
                AllowAttachments = tickets.AllowAttachments
            };

            if (tickets.CollaboratorIds != null)
                ticketResponse.CollaboratorIds.AddRange(tickets.CollaboratorIds);

            if (tickets.FollowerIds != null)
                ticketResponse.FollowerIds.AddRange(tickets.FollowerIds);

            if (tickets.EmailCCIds != null)
                ticketResponse.EmailCCIds.AddRange(tickets.EmailCCIds);

            if (tickets.Tags != null)
                ticketResponse.Tags.AddRange(tickets.Tags);

            if (tickets.CustomFields != null)
                ticketResponse.CustomFields.AddRange(tickets.CustomFields);

            if (tickets.SharingAgreementIds != null)
                ticketResponse.SharingAgreementIds.AddRange(tickets.SharingAgreementIds);

            if (tickets.Fields != null)
                ticketResponse.Fields.AddRange(tickets.Fields);

            if (tickets.FollowupIds != null)
                ticketResponse.FollowupIds.AddRange(tickets.FollowupIds);

            return ticketResponse;
        }
    }
}
