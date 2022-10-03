package com.manishrw.spring_mvc_app;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

@SpringBootApplication
@ComponentScan("com.manishrw.spring_mvc_app")
public class SpringMvcAppApplication {

	public static void main(String[] args) {
		SpringApplication.run(SpringMvcAppApplication.class, args);
	}

}
