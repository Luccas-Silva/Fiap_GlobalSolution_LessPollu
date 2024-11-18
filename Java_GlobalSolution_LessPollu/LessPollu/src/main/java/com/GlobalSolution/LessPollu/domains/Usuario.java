package com.GlobalSolution.LessPollu.domains;

import jakarta.persistence.*;
import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
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
public class Usuario {

    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private String Id;

    @NotBlank(message = "O campo Nome não pode ser deixado em branco")
    @Size(min = 3, max = 50, message = "O campo Nome deve ter entre 3 e 50 caracteres")
    private String Nome;

    @NotBlank(message = "O campo Email não pode ser deixado em branco")
    @Email(message = "Email inválido")
    private String Email;

    @NotBlank(message = "O campo Senha não pode ser deixado em branco")
    @Size(min = 8, message = "Senha deve ter pelo menos 8 caracteres")
    private String Senha;

    @OneToMany(cascade = CascadeType.ALL)
    private List<Relatorio> relatorios;

}
