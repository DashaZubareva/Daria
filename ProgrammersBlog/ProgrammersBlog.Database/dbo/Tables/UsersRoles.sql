CREATE TABLE [dbo].[UsersRoles] (
    [RoleId]      INT NOT NULL,
    [Role_RoleId] INT NOT NULL,
    CONSTRAINT [PK_dbo.UsersRoles] PRIMARY KEY CLUSTERED ([RoleId] ASC, [Role_RoleId] ASC),
    CONSTRAINT [FK_dbo.UsersRoles_dbo.Roles_Role_RoleId] FOREIGN KEY ([Role_RoleId]) REFERENCES [dbo].[Roles] ([RoleId]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.UsersRoles_dbo.Users_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[UsersRoles]([RoleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Role_RoleId]
    ON [dbo].[UsersRoles]([Role_RoleId] ASC);

