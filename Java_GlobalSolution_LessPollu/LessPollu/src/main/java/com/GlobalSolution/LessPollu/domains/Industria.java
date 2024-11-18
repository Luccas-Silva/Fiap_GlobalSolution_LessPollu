package com.GlobalSolution.LessPollu.domains;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.*;

import java.util.List;

@Data
@Builder
@Entity
@NoArgsConstructor
@AllArgsConstructor
@Setter
@Getter
@ToString
public class Industria {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private String Id;

    @NotBlank(message = "O campo Nome não pode ser deixado em branco")
    @Size(min = 3, max = 50, message = "O campo Nome deve ter entre 3 e 50 caracteres")
    private String Nome;

    @NotNull(message = "O campo CEP não pode ser deixado em branco")
    @Size(min = 8, max = 8, message = "CEP must be 8 digits")
    private String CEP;

    @NotBlank(message = "O campo Tipo não pode ser deixado em branco")
    private String Tipo;

    @OneToMany(cascade = CascadeType.ALL)
    private List<Relatorio> relatorios;

}
