using System;
using System.Collections.Generic;

namespace Zendesk.Ticket.Viewer.UnitTests
{
    public class TicketBuilder
    {
        private Domain.Ticket _request;

        private string _url;
        private int _id;
        private int _externalId;
        private string _createdAt;
        private string _updatedAt;
        private string _type;
        private string _subject;
        private string _rawSubject;
        private string _priority;
        private string _status;
        private string _description;
        private string _recipient;
        private string _requesterId;
        private string _submitterId;
        private string _assigneeId;
        private string _organizationId;
        private string _groupId;
        private string _forumTopicId;
        private string _problemId;
        private bool _hasIncidents;
        private bool _isPublic;
        private string _dueAt;
        private string _satisfactionRating;
        private string _ticketFormId;
        private string _brandId;
        private bool _allowChannelBack;
        private bool _allowAttachments;
        private List<string> _collaboratorIds;
        private List<string> _followerIds;
        private List<string> _emailCCIds;
        private List<string> _tags;
        private List<string> _customFields;
        private List<string> _sharingAgreementIds;
        private List<string> _fields;
        private List<string> _followupIds;

        internal TicketBuilder()
        {
            _url = "https://test.com";
            _id = 1;
            _externalId = 11;
            _createdAt = DateTime.UtcNow.ToString();
            _updatedAt = DateTime.UtcNow.ToString();
            _type = "type";
            _subject = "subject";
            _rawSubject = "raw subject";
            _priority = "high";
            _status = "active";
            _description = "description";
            _recipient = "customer";
            _requesterId = Guid.NewGuid().ToString();
            _submitterId = Guid.NewGuid().ToString();
            _assigneeId = Guid.NewGuid().ToString();
            _organizationId = Guid.NewGuid().ToString();
            _groupId = Guid.NewGuid().ToString();
            _forumTopicId = Guid.NewGuid().ToString();
            _problemId = Guid.NewGuid().ToString();
            _hasIncidents = false;
            _isPublic = false;
            _dueAt = DateTime.UtcNow.ToString();
            _satisfactionRating = Guid.NewGuid().ToString();
            _ticketFormId = Guid.NewGuid().ToString();
            _brandId = Guid.NewGuid().ToString();
            _allowChannelBack = false;
            _allowAttachments = false;
            _collaboratorIds = new List<string>();
            _followerIds = new List<string>();
            _emailCCIds = new List<string>();
            _tags = new List<string>();
            _customFields = new List<string>();
            _sharingAgreementIds = new List<string>();
            _fields = new List<string>();
            _followupIds = new List<string>();
        }

        internal Domain.Ticket Build()
        {
            _request = new Domain.Ticket()
            {
                URL = _url,
                Id = _id,
                ExternalId = _externalId,
                CreatedAt = _createdAt,
                UpdatedAt = _updatedAt,
                Type = _type,
                Subject = _subject,
                RawSubject = _rawSubject,
                Priority = _priority,
                Status = _status,
                Description = _description,
                Recipient = _recipient,
                RequesterId = _requesterId,
                SubmitterId = _submitterId,
                AssigneeId = _assigneeId,
                OrganizationId = _organizationId,
                GroupId = _groupId,
                ForumTopicId = _forumTopicId,
                ProblemId = _problemId,
                HasIncidents = _hasIncidents,
                IsPublic = _isPublic,
                DueAt = _dueAt,
                SatisfactionRating = _satisfactionRating,
                TicketFormId = _ticketFormId,
                BrandId = _brandId,
                AllowChannelBack = _allowChannelBack,
                AllowAttachments = _allowAttachments
            };

            _request.CollaboratorIds.AddRange(_collaboratorIds);
            _request.FollowerIds.AddRange(_followerIds);
            _request.EmailCCIds.AddRange(_emailCCIds);
            _request.Tags.AddRange(_tags);
            _request.CustomFields.AddRange(_customFields);
            _request.SharingAgreementIds.AddRange(_sharingAgreementIds);
            _request.Fields.AddRange(_fields);
            _request.FollowupIds.AddRange(_followupIds);

            return _request;
        }


        internal TicketBuilder SetURL(string url)
        {
            _url = url;
            return this;
        }

        internal TicketBuilder SetId(int id)
        {
            _id = id;
            return this;
        }

        internal TicketBuilder SetExternalId(int externalId)
        {
            _externalId = externalId;
            return this;
        }

        internal TicketBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        internal TicketBuilder SetType(string type)
        {
            _type = type;
            return this;
        }

        internal TicketBuilder SetCollaboratorIds(List<string> collaboratorIds)
        {
            _collaboratorIds = collaboratorIds;
            return this;
        }

        internal TicketBuilder SetCreatedAt(string createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        internal TicketBuilder SetUpdatedAt(string updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }

        internal TicketBuilder SetFollowerIds(List<string> followerIds)
        {
            _followerIds = followerIds;
            return this;
        }
    }
}
