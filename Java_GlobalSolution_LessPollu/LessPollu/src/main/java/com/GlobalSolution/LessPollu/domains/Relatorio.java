package com.GlobalSolution.LessPollu.domains;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.PastOrPresent;
import lombok.*;

import java.time.LocalDate;

@Data
@Builder
@Entity
@NoArgsConstructor
@AllArgsConstructor
@Setter
@Getter
@ToString
public class Relatorio {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private String Id;

    @NotNull(message = "O campo Data de Geração não pode ser deixado em branco")
    @PastOrPresent(message = "O campo Data de Geração não pode ser uma Data do Futuro")
    private LocalDate dataGeracao;

    @NotBlank(message = "O campo Período de Cobertura não pode ser deixado em branco")
    private String periodoCobertura;

    @NotBlank(message = "O campo Métricas não podem ser deixado em branco")
    private String Metricas;

    private String Observacoes;

    @OneToOne(cascade = CascadeType.ALL)
    private Usuario usuario;

    @OneToOne(cascade = CascadeType.ALL)
    private Industria industria;

}
