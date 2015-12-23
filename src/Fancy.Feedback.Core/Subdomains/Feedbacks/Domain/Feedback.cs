using Fancy.Feedback.Core.Subdomains.Feedbacks.Domain.ValueObjects;

namespace Fancy.Feedback.Core.Subdomains.Feedbacks.Domain
{
    /// <summary>
    /// A feedback to a specific session
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual long Id { get; set; }

        /// <summary>
        /// Gets or sets the session identifier this feedback belongs to.
        /// </summary>
        /// <value>
        /// The session identifier.
        /// </value>
        public virtual long SessionId { get; set; }

        /// <summary>
        /// Gets or sets the topic met teaser rating.
        /// </summary>
        /// <value>
        /// The topic met teaser rating.
        /// </value>
        public virtual byte TopicMetTeaserRating { get; set; }

        /// <summary>
        /// Gets or sets the speed of speaking rating.
        /// </summary>
        /// <value>
        /// The speed of speaking rating.
        /// </value>
        public virtual byte SpeedOfSpeakingRating { get; set; }

        /// <summary>
        /// Gets or sets the questions properly answered rating.
        /// </summary>
        /// <value>
        /// The questions properly answered rating.
        /// </value>
        public virtual byte QuestionsProperlyAnsweredRating { get; set; }
    }
}
