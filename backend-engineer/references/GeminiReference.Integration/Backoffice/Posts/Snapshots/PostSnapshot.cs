using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Integration.Backoffice.Posts.Snapshots
{
    public class PostSnapshot : Snapshot
    {
        public static readonly string PublicSnapshotName =
            "GeminiReference.Backoffice.Posts.PostSnapshot";
        public override string SnapshotName => PublicSnapshotName;

        public required Guid PostId { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
