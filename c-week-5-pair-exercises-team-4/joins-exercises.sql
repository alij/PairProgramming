use world
-- Write queries to return the following:
-- The following queries utilize the "world" database.

-- 1. The city name, country name, and city population of all cities in Europe with population greater than 1 million
-- (36 rows)
select city.name, country.name, city.population from city
join country on city.countrycode = country.code
where city.population > 1000000 and country.continent = 'Europe'
-- 2. The city name, country name, and city population of all cities in countries where French is an official language and the city population is greater than 1 million
-- (2 rows)
select city.name, country.name, city.population from city
join country on city.countrycode = country.code
join countrylanguage on city.countrycode = countrylanguage.countrycode
where city.population > 1000000 and 
(countrylanguage.language = 'French' and countrylanguage.isofficial = 1)

-- 3. The name of the countries and continents where the language Javanese is spoken
-- (1 row)
select country.name, continent from country 
join countrylanguage on countrylanguage.countrycode = country.code
where language = 'Javanese'
-- 4. The names of all of the countries in Africa that speak French as an official language
-- (5 row)
select country.name from country
join countrylanguage on countrylanguage.countrycode = country.code
where language = 'French' and continent ='Africa' and isofficial = 1

-- 5. The average city population of cities in Europe
-- (average city population in Europe: 287,684)
select AVG(city.population) as avg_population from city
join country on city.countrycode = code
where continent = 'europe'

-- 6. The average city population of cities in Asia
-- (average city population in Asia: 395,019)
select AVG(city.population) as avg_population from city
join country on city.countrycode = code
where continent = 'Asia'

-- 7. The number of cities in countries where English is an official language
-- (number of cities where English is official language: 523)
select count(city.name) from city
join countrylanguage on countrylanguage.countrycode = city.countrycode
where language = 'english' and isofficial = 1

-- 8. The average population of cities in countries where the official language is English
-- (average population of cities where English is official language: 285,809)
select AVG(city.population) as avg_population from city
join countrylanguage on countrylanguage.countrycode = city.countrycode
where language = 'english' and isofficial = 1

-- 9. The names of all of the continents and the population of the continent’s largest city
-- (6 rows, largest population for North America: 8,591,309)
select max(city.population), continent from city
join country on city.countrycode = code
group by continent


-- 10. The names of all of the cities in South America that have a population of more than 1 million people and the official language of each city’s country
-- (29 rows)
select city.population, language,continent from city
join country on city.countrycode = code
join countrylanguage on countrylanguage.countrycode = city.countrycode
where continent = 'south america' and isofficial = 1 and city.population > 1000000