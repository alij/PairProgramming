use world
-- Write queries to return the following:
-- Make the following changes in the "world" database.

-- 1. Add Superman's hometown, Smallville, Kansas to the city table. The 
-- countrycode is 'USA', and population of 45001. (Yes, I looked it up on 
-- Wikipedia.)
insert into city values ('Smallville', 'USA', 'Kansas', 45001)

-- 2. Add Kryptonese to the countrylanguage table. Kryptonese is spoken by 0.0001
-- percentage of the 'USA' population.
insert into countrylanguage values ('USA', 'Kryptonese', 0, 0.0001)
SELECT * from countrylanguage where countrycode = 'USA'

-- 3. After heated debate, "Kryptonese" was renamed to "Krypto-babble", change 
-- the appropriate record accordingly.
update countrylanguage set language = 'Krypto-babble' where language = 'Kryptonese'

-- 4. Set the US captial to Smallville, Kansas in the country table.
select * from country where code = 'USA'

update country set capital = 4080 where code = 'USA'

-- 5. Delete Smallville, Kansas from the city table. (Did it succeed? Why?)
delete city where name = 'Smallville'
This fails because the country table references Smallville as a foreign key.

-- 6. Return the US captial to Washington.
update country set capital = 3813 where code = 'USA'

-- 7. Delete Smallville, Kansas from the city table. (Did it succeed? Why?)
delete city where name = 'Smallville'
This succeeds now that we have removed references to Smallvilles primary key from the country table.

-- 8. Reverse the "is the official language" setting for all languages where the
-- country's year of independence is within the range of 1800 and 1972 
-- (exclusive). 
-- (590 rows affected)
select * from countrylanguage
join country on country.code = countrylanguage.countrycode
where indepyear between 1800 and 1972
update countrylanguage set isofficial = ~isofficial


-- 9. Convert population so it is expressed in 1,000s for all cities. (Round to
-- the nearest integer value greater than 0.)
-- (4079 rows affected)
update city set population = population/1000 -- ooops, should have used WHERE population >= 1000
update city set population = 1 where population = 0
select * from city order by population 

-- 10. Assuming a country's surfacearea is expressed in miles, convert it to 
-- meters for all countries where French is spoken by more than 20% of the 
-- population.
-- (7 rows affected)

select name, surfacearea, language, percentage from country
join countrylanguage on countrylanguage.countrycode = country.code
where language = 'French' and percentage > 20
update country set surfacearea = surfacearea * 1609.34