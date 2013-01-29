﻿using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.Workflows.Models;
using Orchard.Workflows.Services;

namespace Orchard.Workflows.Activities {
    public class PublishActivity : Task {
        private readonly IContentManager _contentManager;

        public PublishActivity(IContentManager contentManager) {
            _contentManager = contentManager;
        }

        public Localizer T { get; set; }

        public override bool CanExecute(WorkflowContext context) {
            return true;
        }

        public override IEnumerable<LocalizedString> GetPossibleOutcomes(WorkflowContext context) {
            return new[] { T("Published") };
        }

        public override IEnumerable<LocalizedString> Execute(WorkflowContext context) {
            _contentManager.Publish(context.Content.ContentItem);
            yield return T("Published");
        }

        public override string Name {
            get { return "Publish"; }
        }

        public override LocalizedString Category {
            get { return T("Content Items"); }
        }

        public override LocalizedString Description {
            get { return T("Published the content item."); }
        }
    }
}