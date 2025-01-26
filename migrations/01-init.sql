create table "Fruits" (
	"id" serial primary key,
	"name" text not null,
	"color" text not null,
	"createdAt" timestamp(3) not null default now()
);