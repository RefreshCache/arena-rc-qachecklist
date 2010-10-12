
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


/* 
** CREATING:
** cust_refreshcache_qachk_testcase
*/
CREATE TABLE [dbo].[cust_refreshcache_qachk_testcase](
	[test_case_id] [int] IDENTITY(1,1) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[date_modified] [datetime] NOT NULL,
	[created_by] [varchar](50) NOT NULL,
	[modified_by] [varchar](50) NOT NULL,
	[case_name] [varchar](50) NOT NULL,
	[case_description] [varchar](max) NULL,
	[case_category_luid] [int] NULL,
 CONSTRAINT [PK_cust_refreshcache_qachk_testcase] PRIMARY KEY CLUSTERED 
(
	[test_case_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testcase]  WITH CHECK ADD  CONSTRAINT [FK_cust_refreshcache_qachk_testcase_core_lookup] FOREIGN KEY([case_category_luid])
REFERENCES [dbo].[core_lookup] ([lookup_id])
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testcase] CHECK CONSTRAINT [FK_cust_refreshcache_qachk_testcase_core_lookup]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testcase] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testcase_date_created]  DEFAULT (getdate()) FOR [date_created]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testcase] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testcase_date_modified]  DEFAULT (getdate()) FOR [date_modified]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testcase] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testcase_created_by]  DEFAULT ('') FOR [created_by]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testcase] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testcase_modified_by]  DEFAULT ('') FOR [modified_by]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testcase] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testcase_case_name]  DEFAULT ('') FOR [case_name]
GO


/* 
** CREATING:
** cust_refreshcache_qachk_releaseversion
*/
CREATE TABLE [dbo].[cust_refreshcache_qachk_releaseversion](
	[release_version_id] [int] IDENTITY(1,1) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[date_modified] [datetime] NOT NULL,
	[created_by] [varchar](50) NOT NULL,
	[modified_by] [varchar](50) NOT NULL,
	[version_number] [varchar](50) NOT NULL,
	[version_type_luid] [int] NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_cust_refreshcache_qachk_releaseversion] PRIMARY KEY CLUSTERED 
(
	[release_version_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_releaseversion]  WITH CHECK ADD  CONSTRAINT [FK_cust_refreshcache_qachk_releaseversion_core_lookup] FOREIGN KEY([version_type_luid])
REFERENCES [dbo].[core_lookup] ([lookup_id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_releaseversion] CHECK CONSTRAINT [FK_cust_refreshcache_qachk_releaseversion_core_lookup]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_releaseversion] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_releaseversion_date_created]  DEFAULT (getdate()) FOR [date_created]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_releaseversion] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_releaseversion_date_modified]  DEFAULT (getdate()) FOR [date_modified]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_releaseversion] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_releaseversion_created_by]  DEFAULT ('') FOR [created_by]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_releaseversion] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_releaseversion_modified_by]  DEFAULT ('') FOR [modified_by]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_releaseversion] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_releaseversion_version_number]  DEFAULT ('') FOR [version_number]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_releaseversion] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_releaseversion_active]  DEFAULT ((1)) FOR [active]
GO

/* 
** CREATING:
** cust_refreshcache_qachk_testresult
*/
CREATE TABLE [dbo].[cust_refreshcache_qachk_testresult](
	[test_result_id] [int] IDENTITY(1,1) NOT NULL,
	[date_created] [datetime] NOT NULL,
	[date_modified] [datetime] NOT NULL,
	[created_by] [varchar](50) NOT NULL,
	[modified_by] [varchar](50) NOT NULL,
	[release_version_id] [int] NOT NULL,
	[test_case_id] [int] NOT NULL,
	[church_id] [varchar](50) NULL,
	[result_status] [bit] NOT NULL,
	[notes] [varchar](max) NULL,
 CONSTRAINT [PK_cust_refreshcache_qachk_testresult] PRIMARY KEY CLUSTERED 
(
	[test_result_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult]  WITH CHECK ADD  CONSTRAINT [FK_cust_refreshcache_qachk_testresult_cust_refreshcache_qachk_releaseversion] FOREIGN KEY([release_version_id])
REFERENCES [dbo].[cust_refreshcache_qachk_releaseversion] ([release_version_id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult] CHECK CONSTRAINT [FK_cust_refreshcache_qachk_testresult_cust_refreshcache_qachk_releaseversion]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult]  WITH CHECK ADD  CONSTRAINT [FK_cust_refreshcache_qachk_testresult_cust_refreshcache_qachk_testcase] FOREIGN KEY([test_case_id])
REFERENCES [dbo].[cust_refreshcache_qachk_testcase] ([test_case_id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult] CHECK CONSTRAINT [FK_cust_refreshcache_qachk_testresult_cust_refreshcache_qachk_testcase]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testresult_date_created]  DEFAULT (getdate()) FOR [date_created]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testresult_date_modified]  DEFAULT (getdate()) FOR [date_modified]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testresult_created_by]  DEFAULT ('') FOR [created_by]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testresult_modified_by]  DEFAULT ('') FOR [modified_by]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_testresult] ADD  CONSTRAINT [DF_cust_refreshcache_qachk_testresult_result_status]  DEFAULT ((0)) FOR [result_status]
GO

/* 
** CREATING:
** cust_refreshcache_qachk_favorite
*/

CREATE TABLE [dbo].[cust_refreshcache_qachk_favorite](
	[test_case_id] [int] NOT NULL,
	[person_id] [int] NOT NULL,
 CONSTRAINT [PK_cust_refreshcache_qachk_favorite] PRIMARY KEY CLUSTERED 
(
	[test_case_id] ASC,
	[person_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_favorite]  WITH CHECK ADD  CONSTRAINT [FK_cust_refreshcache_qachk_favorite_core_person] FOREIGN KEY([person_id])
REFERENCES [dbo].[core_person] ([person_id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_favorite] CHECK CONSTRAINT [FK_cust_refreshcache_qachk_favorite_core_person]
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_favorite]  WITH CHECK ADD  CONSTRAINT [FK_cust_refreshcache_qachk_favorite_cust_refreshcache_qachk_testcase] FOREIGN KEY([test_case_id])
REFERENCES [dbo].[cust_refreshcache_qachk_testcase] ([test_case_id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[cust_refreshcache_qachk_favorite] CHECK CONSTRAINT [FK_cust_refreshcache_qachk_favorite_cust_refreshcache_qachk_testcase]
GO