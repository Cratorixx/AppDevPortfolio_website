using App_Dev.Models;

namespace App_Dev.Services;

public class FakePortfolioService : IPortfolioService
{
    private readonly List<PortfolioMetric> _heroMetrics =
    [
        new("10+", "Production Builds"),
        new("4.6★", "Avg App Rating"),
        new("50k", "Tasks/Sec Throughput"),
        new("3+", "Years Shipping")
    ];

    private readonly List<string> _codeSnippetLines =
    [
        "class TaskOrchestrator {",
        "    private val queue =",
        "        PriorityBlockingQueue<Task>()",
        "",
        "    fun dispatch(task: Task) {",
        "        queue.offer(task)",
        "        syncToRemote(task.id)",
        "    }",
        "",
        "    suspend fun syncToRemote(",
        "        id: UUID",
        "    ) = withContext(IO) {"
    ];

    private readonly List<SystemTopologyNode> _nodes =
    [
        new(
            Id: "android-client",
            Name: "Android Client",
            Subtitle: "MVVM + Compose",
            TechStack: "Kotlin, Jetpack Compose, Coroutines Flow, Room DB",
            Description: "Mobile client application featuring optimistic UI updates, local SQLite caching, and bi-directional WebSocket connectivity.",
            Throughput: "120 fps animations / sub-16ms latency",
            Protocol: "WSS & HTTP/2 with binary Protobuf payloads",
            FailureMode: "Local queue buffering with exponential retry and CRDT conflict merge upon reconnect",
            ThemeColor: "purple"
        ),
        new(
            Id: "websocket-gateway",
            Name: "WebSocket Gateway",
            Subtitle: "Netty NIO",
            TechStack: "Java 21, Netty 4.1, Epoll Transport",
            Description: "High-concurrency reverse proxy terminating TLS and managing persistent full-duplex TCP connections for mobile subscribers.",
            Throughput: "100k concurrent active connections per pod",
            Protocol: "WebSocket frame parsing, Heartbeat ping/pong (15s)",
            FailureMode: "Graceful reconnection tokens with session resumption in Redis",
            ThemeColor: "cyan"
        ),
        new(
            Id: "event-bus",
            Name: "Event Bus",
            Subtitle: "Kafka Streams",
            TechStack: "Apache Kafka, Schema Registry, RocksDB state stores",
            Description: "Distributed event broker streaming partition-ordered change events to downstream workers and conflict resolution services.",
            Throughput: "250k msgs/sec with p99 < 8ms latency",
            Protocol: "Kafka binary wire protocol with Snappy compression",
            FailureMode: "In-sync replicas (min.isr=2), dead-letter queue routing for corrupt envelopes",
            ThemeColor: "emerald"
        ),
        new(
            Id: "task-orchestrator",
            Name: "Task Orchestrator",
            Subtitle: "Spring Boot",
            TechStack: "Kotlin, Spring Boot 3, Project Reactor, Virtual Threads",
            Description: "Coordinates distributed tasks, validates business constraints, and schedules work items across distributed execution workers.",
            Throughput: "50,000 tasks/second non-blocking throughput",
            Protocol: "gRPC internal service mesh + Kafka consumers",
            FailureMode: "Distributed circuit breakers (Resilience4j) with automated fallback to cached state",
            ThemeColor: "purple"
        ),
        new(
            Id: "conflict-resolver",
            Name: "Conflict Resolver",
            Subtitle: "Vector Clocks",
            TechStack: "Rust / C++ FFI core, Vector Clocks, LWW-Element-Set CRDT",
            Description: "Resolves concurrent multi-device mutations without data loss, computing deterministic state reconciliations in sub-millisecond windows.",
            Throughput: "15,000 conflicts/sec resolution rate",
            Protocol: "In-memory lock-free lockless RingBuffer (Disruptor)",
            FailureMode: "Last-write-wins fallback with tombstone logging and conflict notification broadcast",
            ThemeColor: "amber"
        ),
        new(
            Id: "persistence-layer",
            Name: "Persistence Layer",
            Subtitle: "PostgreSQL + Redis",
            TechStack: "PostgreSQL 16 (TimescaleDB), Redis Cluster 7.2",
            Description: "Hybrid persistence architecture utilizing PostgreSQL for durable relational storage and Redis for active session caches and vector clocks.",
            Throughput: "40k reads/sec, 12k writes/sec",
            Protocol: "TCP connection pool (HikariCP / Lettuce)",
            FailureMode: "Automated replica failover, Write-Ahead Logging (WAL) replication",
            ThemeColor: "teal"
        )
    ];

    private readonly List<SimulationTaskItem> _simulationTasks =
    [
        new(1, "Sprint #14 · Active", "Active", 75, "emerald"),
        new(2, "Deploy pipeline · Running", "Running", 65, "amber"),
        new(3, "Auth service · Healthy", "Healthy", 80, "cyan"),
        new(4, "DB backups · Complete", "Complete", 100, "purple"),
        new(5, "Monitoring · Online", "Online", 80, "teal")
    ];

    private readonly List<ProjectItem> _projects =
    [
        new(
            Id: "flowtrack",
            Title: "FlowTrack — Real-time Task Orchestration",
            Subtitle: "Distributed team task management with optimistic UI and conflict resolution",
            Description: "Designed and shipped a production Android app for distributed team task management. Solved real-time sync under poor connectivity using optimistic UI updates with conflict resolution.",
            Category: ProjectCategory.MobileApps,
            Tags: ["MVP", "JAVA/ANDROID", "WEBSOCKET"],
            HighlightMetric: "3.2× faster task resolution vs. baseline",
            ArchitectureFootnote: "ARCHITECTURE: MVC/MVP + CLEAN ARCHITECTURE",
            Stars: 284,
            Commits: 612,
            WatermarkType: "radar",
            AccentColor: "#7c3aed",
            DemoUrl: "/architecture",
            SourceUrl: "https://github.com/Cratorixx",
            IsFeatured: true
        ),
        new(
            Id: "concur",
            Title: "Concur — Async Job Queue Engine",
            Subtitle: "Lock-free, priority-based job scheduler",
            Description: "A lock-free, priority-based job scheduler built from first principles in Java. Handles 50k+ tasks/sec with zero blocking.",
            Category: ProjectCategory.BackendConcurrency,
            Tags: ["JAVA", "THREADPOOL"],
            HighlightMetric: "50k tasks/sec throughput",
            ArchitectureFootnote: "ARCHITECTURE: DISRUPTOR RING BUFFER + LOCK-FREE QUEUES",
            Stars: 419,
            Commits: 348,
            WatermarkType: "radar",
            AccentColor: "#38bdf8",
            DemoUrl: "/architecture",
            SourceUrl: "https://github.com/Cratorixx",
            IsFeatured: false
        ),
        new(
            Id: "forma",
            Title: "Forma — Design System Toolkit",
            Subtitle: "Token-driven accessible component library",
            Description: "A token-driven, accessible component library used across 4 internal products. Ships dark/light mode, 60+ components.",
            Category: ProjectCategory.UIUX,
            Tags: ["REACT", "FIGMA"],
            HighlightMetric: "60+ accessible components",
            ArchitectureFootnote: "ARCHITECTURE: ATOMIC DESIGN + HEADLESS PRIMITIVES",
            Stars: 195,
            Commits: 520,
            WatermarkType: "crosshair",
            AccentColor: "#8b5cf6",
            DemoUrl: "/architecture",
            SourceUrl: "https://github.com/Cratorixx",
            IsFeatured: false
        )
    ];

    public Task<IReadOnlyList<PortfolioMetric>> GetHeroMetricsAsync()
    {
        return Task.FromResult<IReadOnlyList<PortfolioMetric>>(_heroMetrics);
    }

    public Task<IReadOnlyList<string>> GetCodeSnippetLinesAsync()
    {
        return Task.FromResult<IReadOnlyList<string>>(_codeSnippetLines);
    }

    public Task<IReadOnlyList<SystemTopologyNode>> GetTopologyNodesAsync()
    {
        return Task.FromResult<IReadOnlyList<SystemTopologyNode>>(_nodes);
    }

    public Task<SystemTopologyNode?> GetTopologyNodeByIdAsync(string id)
    {
        var node = _nodes.FirstOrDefault(n => n.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(node);
    }

    public Task<IReadOnlyList<ProjectItem>> GetProjectsAsync(ProjectCategory category = ProjectCategory.All)
    {
        if (category == ProjectCategory.All)
        {
            return Task.FromResult<IReadOnlyList<ProjectItem>>(_projects);
        }

        var filtered = _projects.Where(p => p.Category == category).ToList();
        return Task.FromResult<IReadOnlyList<ProjectItem>>(filtered);
    }

    public Task<ProjectItem?> GetFeaturedProjectAsync()
    {
        var featured = _projects.FirstOrDefault(p => p.IsFeatured);
        return Task.FromResult(featured);
    }

    public Task<IReadOnlyList<SimulationTaskItem>> GetSimulationTasksAsync()
    {
        return Task.FromResult<IReadOnlyList<SimulationTaskItem>>(_simulationTasks.ToList());
    }

    public Task<SimulationTaskItem> RefreshSimulationTaskAsync(int taskId)
    {
        var index = _simulationTasks.FindIndex(t => t.Id == taskId);
        if (index >= 0)
        {
            var task = _simulationTasks[index];
            var newProgress = task.ProgressPercent >= 100 ? 30 : Math.Min(100, task.ProgressPercent + 15);
            var newStatus = newProgress switch
            {
                >= 100 => "Complete",
                >= 70 => "Healthy",
                >= 40 => "Running",
                _ => "Active"
            };
            var updated = task with { ProgressPercent = newProgress, Status = newStatus };
            _simulationTasks[index] = updated;
            return Task.FromResult(updated);
        }

        throw new KeyNotFoundException($"Task with id {taskId} not found.");
    }

    public Task<CaseStudyDetail> GetCaseStudyAsync(string id = "flowtrack")
    {
        var caseStudy = new CaseStudyDetail(
            ProjectId: "flowtrack",
            Title: "FlowTrack: System Design Deep Dive",
            Subtitle: "03 · SYSTEM CASE STUDY",
            Problem: "Teams needed real-time task sync across unstable mobile connections without data loss or conflicts.",
            Solution: "Event-sourced state with vector clocks for conflict detection; optimistic UI updates reverted on conflict; WebSocket with HTTP/2 fallback.",
            DataStructures:
            [
                "Priority Queue (task scheduling)",
                "LRU Cache (offline state)",
                "Vector Clock (conflict resolution)",
                "Merkle Tree (sync integrity)"
            ],
            TechnicalHurdles:
            [
                new("01", "Network Partitions", "Solved with CRDT-inspired merge strategy"),
                new("02", "Battery Efficiency", "Adaptive sync intervals based on activity"),
                new("03", "Cold Start Latency", "Lazy hydration with skeleton UI")
            ],
            CrashFreeRate: "98.3%",
            StoreRating: "4.6★",
            Nodes: _nodes
        );

        return Task.FromResult(caseStudy);
    }

    public async Task<bool> SubmitInquiryAsync(ContactInquiryModel inquiry)
    {
        // Simulate asynchronous network/database roundtrip
        await Task.Delay(800);
        return true;
    }

    private static readonly List<ReviewItem> _reviews =
    [
        new(
            Id: "rev-1",
            AuthorName: "Elena Rostova",
            AuthorRole: "Senior Android Tech Lead @ Nexa",
            ProjectOrTopic: "FlowTrack Mobile App",
            Rating: 5,
            Comment: "The offline-first architecture with vector clock conflict resolution in FlowTrack is phenomenal. We benchmarked it during harsh cellular network degradation and observed zero state divergence or data loss. Superb execution!",
            CreatedAt: DateTime.UtcNow.AddDays(-12),
            Category: "Mobile Apps",
            AvatarGradient: "from-purple-600 to-indigo-600",
            HelpfulCount: 14
        ),
        new(
            Id: "rev-2",
            AuthorName: "Marcus Vance",
            AuthorRole: "Principal Systems Architect @ CloudScale",
            ProjectOrTopic: "Distributed Event Broker",
            Rating: 5,
            Comment: "Top-tier concurrency design and Netty NIO tuning. Achieving 100k active persistent WebSocket connections per pod while keeping memory footprint lean is no small feat. Very clean boundary separation.",
            CreatedAt: DateTime.UtcNow.AddDays(-25),
            Category: "System Architecture",
            AvatarGradient: "from-cyan-600 to-blue-600",
            HelpfulCount: 9
        ),
        new(
            Id: "rev-3",
            AuthorName: "Claire Zhang",
            AuthorRole: "Product Design Lead @ Studio Apex",
            ProjectOrTopic: "UI/UX & Design Systems",
            Rating: 5,
            Comment: "It is exceptionally rare to find an engineer who writes high-throughput backend code while having this level of finesse for micro-interactions, dark mode telemetry, and sub-16ms layout animations. A pleasure to collaborate with!",
            CreatedAt: DateTime.UtcNow.AddDays(-34),
            Category: "UI/UX",
            AvatarGradient: "from-emerald-600 to-teal-600",
            HelpfulCount: 6
        ),
        new(
            Id: "rev-4",
            AuthorName: "David Thorne",
            AuthorRole: "Open Source Core Maintainer",
            ProjectOrTopic: "Task Orchestrator & CLI Tooling",
            Rating: 4,
            Comment: "Modular architecture, exhaustive unit testing, and highly readable idiomatic code. PRs were thoroughly documented and the CI pipeline runs blazing fast. Solid engineering discipline throughout.",
            CreatedAt: DateTime.UtcNow.AddDays(-48),
            Category: "Code Quality",
            AvatarGradient: "from-amber-600 to-rose-600",
            HelpfulCount: 4
        )
    ];

    public Task<IReadOnlyList<ReviewItem>> GetReviewsAsync()
    {
        lock (_reviews)
        {
            return Task.FromResult<IReadOnlyList<ReviewItem>>(_reviews.OrderByDescending(r => r.CreatedAt).ToList());
        }
    }

    public async Task<ReviewItem> AddReviewAsync(ReviewSubmissionModel submission)
    {
        await Task.Delay(300); // Simulate network latency

        var gradients = new[]
        {
            "from-purple-600 to-pink-600",
            "from-cyan-600 to-teal-600",
            "from-indigo-600 to-blue-600",
            "from-emerald-600 to-cyan-600",
            "from-amber-500 to-orange-600"
        };
        var randomGradient = gradients[Random.Shared.Next(gradients.Length)];

        var newReview = new ReviewItem(
            Id: $"rev-{Guid.NewGuid().ToString("N")[..8]}",
            AuthorName: submission.AuthorName.Trim(),
            AuthorRole: submission.AuthorRole.Trim(),
            ProjectOrTopic: submission.ProjectOrTopic.Trim(),
            Rating: Math.Clamp(submission.Rating, 1, 5),
            Comment: submission.Comment.Trim(),
            CreatedAt: DateTime.UtcNow,
            Category: submission.Category,
            AvatarGradient: randomGradient,
            HelpfulCount: 0
        );

        lock (_reviews)
        {
            _reviews.Insert(0, newReview);
        }

        return newReview;
    }

    public Task<bool> IncrementHelpfulCountAsync(string reviewId)
    {
        lock (_reviews)
        {
            var index = _reviews.FindIndex(r => r.Id == reviewId);
            if (index >= 0)
            {
                var existing = _reviews[index];
                _reviews[index] = existing with { HelpfulCount = existing.HelpfulCount + 1 };
                return Task.FromResult(true);
            }
        }
        return Task.FromResult(false);
    }
}

