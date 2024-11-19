package com.GlobalSolution.LessPollu;

import com.GlobalSolution.LessPollu.domains.Industria;
import com.GlobalSolution.LessPollu.domains.Relatorio;
import com.GlobalSolution.LessPollu.domains.Usuario;
import com.GlobalSolution.LessPollu.gateways.IndustriaRepository;
import com.GlobalSolution.LessPollu.gateways.RelatorioRepository;
import com.GlobalSolution.LessPollu.gateways.UsuarioRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.event.ApplicationReadyEvent;
import org.springframework.context.event.EventListener;

import java.time.LocalDate;
import java.util.Date;

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
		Industria industriaCadastrado = Industria.builder()
				.Nome("Indústria LessPollu")
				.CEP("12345678")
				.Tipo("Manufatura")
				.build();
		industriaRepository.save(industriaCadastrado);
	}

	@EventListener(value = ApplicationReadyEvent.class)
	public void setupUsuario() {
		Usuario usuarioCadastrado = Usuario.builder()
				.Nome("Luccas Silva")
				.Email("luccas@silvae.com")
				.Senha("senha123")
				.build();
		usuarioRepository.save(usuarioCadastrado);
	}

	@EventListener(value = ApplicationReadyEvent.class)
	public void setupRelatorio() {
		LocalDate date = LocalDate.now();
		for (int i=1; i<=3; i++){
			Relatorio relatorioCadastrado = Relatorio.builder()
					.dataGeracao(date)
					.periodoCobertura("Mensal")
					.Metricas("Produtividade, Qualidade")
					.Observacoes("Relatório referente ao mês todo")
					.industria(Industria.builder()
							.Nome("Indústria"+i)
							.CEP("1234000"+i)
							.Tipo("Manufatura")
							.build())
					.usuario(Usuario.builder()
							.Nome("Usuario"+i)
							.Email("usuario"+i+"@example.com")
							.Senha("senha000"+i)
							.build())
					.build();
			relatorioRepository.save(relatorioCadastrado);
		}
	}
}
