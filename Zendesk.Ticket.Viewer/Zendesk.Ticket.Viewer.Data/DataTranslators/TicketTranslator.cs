using System;

namespace Zendesk.Ticket.Viewer.Data
{
    internal static class TicketTranslator
    {
        internal static Domain.Ticket ToDomainModel(this Tickets tickets)
        {
            if (tickets == null)
                return null;

            var ticketDomainModel = new Domain.Ticket()
            {
                URL = tickets.url,
                Id = tickets.id,
                ExternalId = tickets.external_id,
                Description = tickets.description,
                CreatedAt = tickets.created_at,
                UpdatedAt = tickets.updated_at,
                Type = tickets.type,
                Subject = tickets.subject,
                RawSubject = tickets.raw_subject,
                Priority = tickets.priority,
                Status = tickets.status,
                Recipient = tickets.recipient,
                RequesterId = tickets.requester_id,
                SubmitterId = tickets.submitter_id,
                AssigneeId = tickets.assignee_id,
                OrganizationId = tickets.organization_id,
                GroupId = tickets.group_id,
                ForumTopicId = tickets.forum_topic_id,
                ProblemId = tickets.problem_id,
                HasIncidents = tickets.has_incidents,
                IsPublic = tickets.is_public,
                DueAt = tickets.due_at,
                SatisfactionRating = tickets.satisfaction_rating,
                TicketFormId = tickets.ticket_form_id,
                BrandId = tickets.brand_id,
                AllowChannelBack = tickets.allow_channelback,
                AllowAttachments = tickets.allow_attachments
            };

            if (tickets.collaborator_ids != null)
                ticketDomainModel.CollaboratorIds.AddRange(tickets.collaborator_ids);

            if (tickets.follower_ids != null)
                ticketDomainModel.FollowerIds.AddRange(tickets.follower_ids);

            if (tickets.email_cc_ids != null)
                ticketDomainModel.EmailCCIds.AddRange(tickets.email_cc_ids);

            if (tickets.tags != null)
                ticketDomainModel.Tags.AddRange(tickets.tags);

            if (tickets.custom_fields != null)
                ticketDomainModel.CustomFields.AddRange(tickets.custom_fields);

            if (tickets.sharing_agreement_ids != null)
                ticketDomainModel.SharingAgreementIds.AddRange(tickets.sharing_agreement_ids);

            if (tickets.fields != null)
                ticketDomainModel.Fields.AddRange(tickets.fields);

            if (tickets.followup_ids != null)
                ticketDomainModel.FollowupIds.AddRange(tickets.followup_ids);

            return ticketDomainModel;
        }

        internal static Domain.Ticket ToDomainModel(this Ticket tickets)
        {
            if (tickets == null)
                return null;

            var ticketDomainModel = new Domain.Ticket()
            {
                URL = tickets.url,
                Id = tickets.id,
                ExternalId = tickets.external_id,
                Description = tickets.description,
                CreatedAt = tickets.created_at,
                UpdatedAt = tickets.updated_at,
                Type = tickets.type,
                Subject = tickets.subject,
                RawSubject = tickets.raw_subject,
                Priority = tickets.priority,
                Status = tickets.status,
                Recipient = tickets.recipient,
                RequesterId = tickets.requester_id,
                SubmitterId = tickets.submitter_id,
                AssigneeId = tickets.assignee_id,
                OrganizationId = tickets.organization_id,
                GroupId = tickets.group_id,
                ForumTopicId = tickets.forum_topic_id,
                ProblemId = tickets.problem_id,
                HasIncidents = tickets.has_incidents,
                IsPublic = tickets.is_public,
                DueAt = tickets.due_at,
                SatisfactionRating = tickets.satisfaction_rating,
                TicketFormId = tickets.ticket_form_id,
                BrandId = tickets.brand_id,
                AllowChannelBack = tickets.allow_channelback,
                AllowAttachments = tickets.allow_attachments
            };

            if (tickets.collaborator_ids != null)
                ticketDomainModel.CollaboratorIds.AddRange(tickets.collaborator_ids);

            if (tickets.follower_ids != null)
                ticketDomainModel.FollowerIds.AddRange(tickets.follower_ids);

            if (tickets.email_cc_ids != null)
                ticketDomainModel.EmailCCIds.AddRange(tickets.email_cc_ids);

            if (tickets.tags != null)
                ticketDomainModel.Tags.AddRange(tickets.tags);

            if (tickets.custom_fields != null)
                ticketDomainModel.CustomFields.AddRange(tickets.custom_fields);

            if (tickets.sharing_agreement_ids != null)
                ticketDomainModel.SharingAgreementIds.AddRange(tickets.sharing_agreement_ids);

            if (tickets.fields != null)
                ticketDomainModel.Fields.AddRange(tickets.fields);

            if (tickets.followup_ids != null)
                ticketDomainModel.FollowupIds.AddRange(tickets.followup_ids);

            return ticketDomainModel;
        }
    }
}
