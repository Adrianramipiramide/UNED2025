select count(NIF)
from examenes_inap_pro.EXAMENES_NIF
where ID_MODELO LIKE '102' 
group by codtribunal;

select count(NIF)
from examenes_inap_pro.EXAMENES_NIF
where ID_MODELO LIKE '102' 
group by codtribunal;

  
select count(NIF)
from examenes_inap_pro.EXAMENES_NIF
where ID_MODELO LIKE '103' 
group by codtribunal;

select count(NIF)
from examenes_inap_pro.EXAMENES_NIF
where ID_MODELO LIKE '103' 
group by id_modelo;

select count(NIF)
from examenes_inap_pro.EXAMENES_NIF
where ID_MODELO LIKE '103' 
group by id_examen;


select count(nif)
from examenes_inap_pro.EXAMENES_NIF
where id_examen like '1014'
group by codtribunal
;

select count(nif)
from examenes_inap_pro.EXAMENES_NIF
where id_examen like '1014'
group by id_modelo
;


select count(nif)
from examenes_inap_pro.EXAMENES_NIF
where id_examen like '1014'
group by id_examen
;


select count(nif)
from examenes_inap_pro.EXAMENES_NIF
where id_examen like '1015'
group by id_modelo
;


select count(nif)
from examenes_inap_pro.EXAMENES_NIF
where id_examen like '1015'
group by id_examen
;

select count(nif)
from examenes_inap_pro.EXAMENES_NIF
where id_examen like '1015'
group by codtribunal
;

select count(nif)
from examenes_inap_pro.EXAMENES_NIF
where codtribunal like '053039';


select count(nif)
from examenes_inap_pro.EXAMENES_NIF
where codtribunal like '000000';


select count(nif),codtribunal
from examenes_inap_pro.EXAMENES_NIF
group by codtribunal;

SELECT COUNT(nif) AS num_registros, codtribunal
FROM examenes_inap_pro.EXAMENES_NIF
WHERE EXTRACT(MONTH FROM diahora) = 2
  AND EXTRACT(DAY FROM diahora) = 14
GROUP BY codtribunal;

SELECT COUNT(nif) AS num_registros, codtribunal, ID_MODELO, ID_EXAMEN
FROM examenes_inap_pro.EXAMENES_NIF
WHERE EXTRACT(MONTH FROM diahora) = 2
  AND EXTRACT(DAY FROM diahora) = 14
GROUP BY codtribunal, ID_EXAMEN, ID_MODELO;





SELECT 
    p.codtribunal,
    COUNT(p.nif) AS Presentados,
    a.Aspirantes,
    a.Aspirantes - COUNT(p.nif) AS Diferencia
FROM 
    examenes_inap_pro.PRESENCIA p
JOIN 
    (SELECT codtribunal, COUNT(nif) AS Aspirantes
     FROM examenes_inap_pro.examenes_nif
     WHERE EXTRACT(MONTH FROM diahora) = 2
       AND EXTRACT(DAY FROM diahora) = 14
     GROUP BY codtribunal) a
ON p.codtribunal = a.codtribunal
WHERE 
    EXTRACT(MONTH FROM p.diahora) = 2
    AND EXTRACT(DAY FROM p.diahora) = 14
GROUP BY 
    p.codtribunal, a.Aspirantes;


  