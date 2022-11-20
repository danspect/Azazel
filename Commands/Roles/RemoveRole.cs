//MIT License
//
//Copyright (c) 2022 Daniel
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
using System;

using System.Collections.Generic;

using System.Linq;

using System.Threading.Tasks;

using DSharpPlus.CommandsNext;

using DSharpPlus.CommandsNext.Attributes;

using DSharpPlus.Entities;

using DSharpPlus;

namespace Azazel.Commands.Roles;

public class RemoveRole : BaseCommandModule
{
    [
        Command("removerole"),
        Description("Removes a role from the Specified member"),
        RequirePermissions(Permissions.ManageRoles)
    ]
    public async Task TakeRole(CommandContext ctx,[Description("Member To Remove Role From")] DiscordMember member,[Description("Role To Remove From The Specified Member")]DiscordRole role,[Description("Reason To Remove Role From The Specified Member")] string? reason = null)
    {
        await ctx.TriggerTypingAsync().ConfigureAwait(false); 

        try
        {
            await member.RevokeRoleAsync(role, reason);
        }
        catch (System.Exception ex)
        {
            await ctx.RespondAsync("Could not remove the role from the member");
        }

        await ctx.RespondAsync("The role was successfully removed.");
    }
}
