# DOF Exam 2019.02.10 / 2019.02.17
Exam Repository for DevOps Fundamentals Course @ SoftUni

Set of three Docker containters each with dedicated role - php, redis, and nginx, that form a simple web application.

For a successful completion you have to:
 - (re)build the images;
 - (re)run the containers;
 - mount the /app folder where (in terms of path and containers) applicable;

Please note that:
 - each container should be named after the following rule - **role-host**, where role is *php*, *redis*, or *nginx*;
 - nginx is set to listen on port **80**;
 - php files are expected to be in the **/site** folder of both nginx and php containers;
 - nginx container should be started after php;

Use docker-compose.yml file as a starting point when building the final set of application configuration files for the platform of your choice.
