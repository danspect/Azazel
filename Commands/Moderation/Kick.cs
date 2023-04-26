// MIT License
// 
// Copyright (c) 2022 Daniel Aspect
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace Azazel.Commands.Moderation;

public class Kick : BaseCommandModule
{
    [Command("kick"), Description("Kicks a Member From The Server")]
    [RequirePermissions(Permissions.KickMembers), RequireGuild]
    public async Task KickMemberAsync(CommandContext ctx, DiscordMember member, [RemainingText] string? reason = "Reason not specified.")
    {
        if (member.Hierarchy >= ctx.Guild.CurrentMember.Hierarchy)
        {
            await ctx.RespondAsync("You cannot kick this member.");
            return;
        }

        await ctx.RespondAsync($"{member.Mention} was kicked: {reason}");
    }
}
