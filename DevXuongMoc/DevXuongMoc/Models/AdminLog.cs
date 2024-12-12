using System;
using System.Collections.Generic;

namespace DevXuongMoc.Models;

public partial class AdminLog
{
    public int LogId { get; set; }

    public int? Status { get; set; }

    public string? SessionId { get; set; }

    public string? AppCode { get; set; }

    public string? ThreadId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? AdminUserId { get; set; }

    public string? UserLogin { get; set; }

    public string? UserName { get; set; }

    public string? IpAddress { get; set; }

    public string? ActionCode { get; set; }

    public string? ActionName { get; set; }

    public string? MenuCode { get; set; }

    public string? MenuName { get; set; }

    public int? WebpagesActionId { get; set; }

    public int? ActionType { get; set; }

    public int? ObjectId { get; set; }

    public string? Content { get; set; }

    public string? Description { get; set; }

    public int? LogLevel { get; set; }

    public string? ErrorCode { get; set; }
}
