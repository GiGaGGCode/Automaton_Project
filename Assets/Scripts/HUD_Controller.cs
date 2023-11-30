using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Controller : MonoBehaviour
{
    public Button buttonV;
    public Button buttonG;
    public GameObject panelV;
    public GameObject panelG;
    public TMPro.TMP_Dropdown estadoDropdown;
    
    public List<string> estadosList = new List<string>();
    public List<string> abreviacionesList = new List<string>();

    public TMPro.TMP_InputField nombreInputField;
    public TMPro.TMP_InputField apellido1InputField;
    public TMPro.TMP_InputField apellido2InputField;
    public TMPro.TMP_InputField diaInputField;
    public TMPro.TMP_InputField anioInputField;
    public TMPro.TMP_Dropdown mesDropdown;
    public TMPro.TMP_Dropdown sexoDropdown;
    public TMPro.TMP_InputField curpOutputText;

    void Start()
    {
        // Llena las listas con los nombres de los estados y sus abreviaciones
        estadosList.Add("AGUASCALIENTES");
        estadosList.Add("BAJA CALIFORNIA");
        estadosList.Add("BAJA CALIFORNIA SUR");
        estadosList.Add("CAMPECHE");
        estadosList.Add("COAHUILA");
        estadosList.Add("COLIMA");
        estadosList.Add("CHIAPAS");
        estadosList.Add("CHIHUAHUA");
        estadosList.Add("DISTRITO FEDERAL");
        estadosList.Add("DURANGO");
        estadosList.Add("GUANAJUATO");
        estadosList.Add("GUERRERO");
        estadosList.Add("HIDALGO");
        estadosList.Add("JALISCO");
        estadosList.Add("MÉXICO");
        estadosList.Add("MICHOACÁN");
        estadosList.Add("MORELOS");
        estadosList.Add("NAYARIT");
        estadosList.Add("NUEVO LEÓN");
        estadosList.Add("OAXACA");
        estadosList.Add("PUEBLA");
        estadosList.Add("QUERÉTARO");
        estadosList.Add("QUINTANA ROO");
        estadosList.Add("SAN LUIS POTOSÍ");
        estadosList.Add("SINALOA");
        estadosList.Add("SONORA");
        estadosList.Add("TABASCO");
        estadosList.Add("TAMAULIPAS");
        estadosList.Add("TLAXCALA");
        estadosList.Add("VERACRUZ");
        estadosList.Add("YUCATÁN");
        estadosList.Add("ZACATECAS");
        estadosList.Add("EXTRANJERO");

        abreviacionesList.Add("AS");
        abreviacionesList.Add("BC");
        abreviacionesList.Add("BS");
        abreviacionesList.Add("CC");
        abreviacionesList.Add("CL");
        abreviacionesList.Add("CM");
        abreviacionesList.Add("CS");
        abreviacionesList.Add("CH");
        abreviacionesList.Add("DF");
        abreviacionesList.Add("DG");
        abreviacionesList.Add("GT");
        abreviacionesList.Add("GR");
        abreviacionesList.Add("HG");
        abreviacionesList.Add("JC");
        abreviacionesList.Add("MC");
        abreviacionesList.Add("MN");
        abreviacionesList.Add("MS");
        abreviacionesList.Add("NT");
        abreviacionesList.Add("NL");
        abreviacionesList.Add("OC");
        abreviacionesList.Add("PL");
        abreviacionesList.Add("QT");
        abreviacionesList.Add("QR");
        abreviacionesList.Add("SP");
        abreviacionesList.Add("SL");
        abreviacionesList.Add("SR");
        abreviacionesList.Add("TC");
        abreviacionesList.Add("TS");
        abreviacionesList.Add("TL");
        abreviacionesList.Add("VZ");
        abreviacionesList.Add("YN");
        abreviacionesList.Add("ZS");
        abreviacionesList.Add("NE");

        FillDropdownWithStates();
    }

    public void GenerarCURP(){
        // Obtiene los valores de los campos de entrada y Dropdowns
        string nombre = nombreInputField.text.ToUpper();
        string apellido1 = apellido1InputField.text.ToUpper();
        string apellido2 = apellido2InputField.text.ToUpper();
        string dia = diaInputField.text;
        string anio = anioInputField.text;
        string mes = mesDropdown.options[mesDropdown.value].text;
        string sexo = sexoDropdown.options[sexoDropdown.value].text;
        string estado = estadoDropdown.options[estadoDropdown.value].text;

        if(nombre == "" || apellido1 == "" || apellido2 == "" || dia == "" || anio == "" || mes == "" || sexo == "" || estado == ""){
            curpOutputText.text = "Faltan datos";
            return;
        }
        if(nombre.Length < 2 || apellido1.Length < 2 || apellido2.Length < 2 || anio.Length < 4){
            curpOutputText.text = "Datos inválidos";
            return;
        }
        // Realiza el cálculo de la CURP aproximada
        // Puedes usar los valores obtenidos para construir una CURP aproximada
        string curpAproximada = apellido1.Substring(0, 1);
        int tmp = -1;
        for (int i = 1; i < apellido1.Length; i++)
        {
            if (apellido1[i] == 'A' || apellido1[i] == 'E' || apellido1[i] == 'I' || apellido1[i] == 'O' || apellido1[i] == 'U')
            {
                tmp = i;
                break;
            }
        }
        if (tmp != -1)
        {
            curpAproximada += apellido1.Substring(tmp, 1);
        }
        else
        {
            curpAproximada += "X";
        }
        curpAproximada += apellido2.Substring(0, 1);
        curpAproximada += nombre.Substring(0, 1);
        curpAproximada += anio.Substring(2);
        if (mes == "Enero")
        {
            curpAproximada += "01";
        }
        else if (mes == "Febrero")
        {
            curpAproximada += "02";
        }
        else if (mes == "Marzo")
        {
            curpAproximada += "03";
        }
        else if (mes == "Abril")
        {
            curpAproximada += "04";
        }
        else if (mes == "Mayo")
        {
            curpAproximada += "05";
        }
        else if (mes == "Junio")
        {
            curpAproximada += "06";
        }
        else if (mes == "Julio")
        {
            curpAproximada += "07";
        }
        else if (mes == "Agosto")
        {
            curpAproximada += "08";
        }
        else if (mes == "Septiembre")
        {
            curpAproximada += "09";
        }
        else if (mes == "Octubre")
        {
            curpAproximada += "10";
        }
        else if (mes == "Noviembre")
        {
            curpAproximada += "11";
        }
        else if (mes == "Diciembre")
        {
            curpAproximada += "12";
        }
        if(dia.Length == 1){
            curpAproximada += "0" + dia;
        }else curpAproximada += dia;
        curpAproximada += sexo.Substring(0, 1);
        for(int i=0; i<estadosList.Count; i++){
            if(estado == estadosList[i]){
                curpAproximada += abreviacionesList[i];
                break;
            }
        }
        for(int i=1; i<apellido1.Length; i++){
            if(apellido1[i] != 'A' && apellido1[i] != 'E' && apellido1[i] != 'I' && apellido1[i] != 'O' && apellido1[i] != 'U'){
                curpAproximada += apellido1.Substring(i, 1);
                break;
            }
        }
        for(int i=1; i<apellido2.Length; i++){
            if(apellido2[i] != 'A' && apellido2[i] != 'E' && apellido2[i] != 'I' && apellido2[i] != 'O' && apellido2[i] != 'U'){
                if(apellido2[i] == 'Ñ') curpAproximada += "X";
                else{
                    curpAproximada += apellido2.Substring(i, 1);
                }
                break;
            }
        }
        for(int i=1; i<nombre.Length; i++){
            if(nombre[i] != 'A' && nombre[i] != 'E' && nombre[i] != 'I' && nombre[i] != 'O' && nombre[i] != 'U'){
                curpAproximada += nombre.Substring(i, 1);
                break;
            }
        }
        curpAproximada += "A9";

        // Muestra la CURP aproximada en un Text o en donde desees
        if(curpAproximada.Length == 18) curpOutputText.text = curpAproximada;
        else curpOutputText.text = "CURP inválida";
    }

    private void FillDropdownWithStates()
    {
        estadoDropdown.ClearOptions();
        estadoDropdown.AddOptions(estadosList);
    }

    
    public void MostrarPanelV()
    {
        panelV.SetActive(true);
        panelG.SetActive(false);
        buttonV.interactable = false;
        buttonG.interactable = true;
    }

    public void MostrarPanelG()
    {
        panelV.SetActive(false);
        panelG.SetActive(true);
        buttonV.interactable = true;
        buttonG.interactable = false;
    }
}
