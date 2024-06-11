﻿namespace TindogService.Querys
{
    public class Consulta
    {
        public static string ConsultaTutor()
        {
            return $@"select t.nome_tutor,
                t.sobrenome_tutor,
                t.dt_nascimento_tutor,
                t.telefone_tutor,
                g.nome_genero genero_tutor,
                pe.nome_pet,
                r.nome_raca,
                pe.dt_nascimento_pet,
                pe.peso_pet,
                pg.nome_genero genero_pet,
                pe.qtd_vacinas_pet,
                pe.pedigree_pet,
                en.rua_endereco,
                en.numero_endereco,
                en.bairro_endereco,
                en.cep_endereco,
                c.nome_cidade,
                es.nome_estado,
                pa.nome_pais,
                t.id_tutor,
                pe.id_pet,
                en.id_endereco
                from tutor t
                join endereco en on en.id_endereco = t.id_endereco
                join cidade c on c.id_cidade = en.id_cidade
                join estado es on es.id_estado = c.id_estado
                join pais pa on pa.id_pais = es.id_pais
                join genero g on g.id_genero = t.id_genero
                join pet pe on pe.id_tutor = t.id_tutor
                join raca r on r.id_raca = pe.id_raca
                join genero pg on pg.id_genero = pe.id_genero
                where t.nome_tutor = @nome_tutor";
        }
    }
}
