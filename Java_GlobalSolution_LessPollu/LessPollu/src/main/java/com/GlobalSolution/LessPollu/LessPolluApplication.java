package com.GlobalSolution.LessPollu;

import com.GlobalSolution.LessPollu.domains.Industria;
import com.GlobalSolution.LessPollu.gateways.IndustriaRepository;
import com.GlobalSolution.LessPollu.gateways.RelatorioRepository;
import com.GlobalSolution.LessPollu.gateways.UsuarioRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.event.ApplicationReadyEvent;
import org.springframework.context.event.EventListener;

@SpringBootApplication
@RequiredArgsConstructor
public class LessPolluApplication {

	public static void main(String[] args) {
		SpringApplication.run(LessPolluApplication.class, args);
	}

	private final IndustriaRepository industriaRepository;
	private final RelatorioRepository relatorioRepository;
	private final UsuarioRepository usuarioRepository;

	@EventListener(value = ApplicationReadyEvent.class)
	public void setupIndustria() {
		Industria industria = Industria.builder()
				.Nome("")
				.CEP("12345678")
				.Tipo("")
				.build();
	}


}
