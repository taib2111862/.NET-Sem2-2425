create table Categories(
	cat_id INT PRIMARY KEY IDENTITY(0,1),
	cat_name NVARCHAR(255) NOT NULL UNIQUE
);

insert into Categories values
('Other');

create table Videos(
	vid_id INT PRIMARY KEY IDENTITY(1,1),
	vid_title NVARCHAR(255) NOT NULL,
	vid_filepath NVARCHAR(1000) NOT NULL,
	vid_description NVARCHAR(MAX),
	cat_id INT DEFAULT 0,
	FOREIGN KEY (cat_id) REFERENCES Categories(cat_id) ON DELETE SET NULL
);

create table Tags(
	tag_id INT PRIMARY KEY IDENTITY(1,1),
	tag_name NVARCHAR(255) NOT NULL UNIQUE
);

create table VideoTags(
	vid_id INT,
	tag_id INT,
	FOREIGN KEY (vid_id) REFERENCES Videos(vid_id) ON DELETE CASCADE,
	FOREIGN KEY (tag_id) REFERENCES Tags(tag_id) ON DELETE CASCADE,
	PRIMARY KEY (vid_id, tag_id)
);