using UnityEngine.SceneManagement;
private bool isPaused= false;
private Menu menu;
public GameObject pausePainel;

//Dentro do update
if(!isPaused){
    //todas as funções que já estão dentro do update;
}
if(Input.GetKeyDown(KeyCode.Escape))
{
    PauseScreen();
}

//Fora do update
void PauseScreen()
{
    if(isPaused)
    {
        isPaused= false;
        pausePainel.SetActive(false);
    }
    else
    {
        isPaused= true;
        pausePainel.SetActive(true);
    }
}
public void BackToMenu()
{
    menu.ChamaMenu();
}