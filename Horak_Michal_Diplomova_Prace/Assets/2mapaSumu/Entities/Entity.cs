using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    //Základní tøída, kterou následnì dìdí zvíøata i rostliny. Spoleèné funkce jsou v této tøídì
    [SerializeField] protected private int id = -1;

    [SerializeField] protected private int typeEntity = 0;//1-animal,2-plant, 0 error default;

    [SerializeField] protected private int typeEater = 0;//only for animals 1-meateater,2-planteater,3-alleater;

    [SerializeField] protected private int type = 4;//1-tree,2-plant,3-bush,4-grass;

    [SerializeField] protected private float age = 0;//secs

    [SerializeField] protected private float mature_age = 30;//až po dosažení dospìlosti zaènì šíøit semena v okolí jednou za èas

    [SerializeField] protected private bool isMature = false;

    [SerializeField] protected private string kind = "Entity";

    [SerializeField] protected private float hp = 100;

    [SerializeField] protected private float foodValue = 10;

    [SerializeField] protected private float regen_hp = 100;

    [SerializeField] protected private float max_hp = 100;

    [SerializeField] protected private float energy = 0;

    [SerializeField] protected private float energy_regen = 1;//pøi dosažení max energy + dospìlost vyprodukuje jedno semínko v okolí

    [SerializeField] protected private float max_energy = 100;

    [SerializeField] protected private float ageForDie = 360;

    [SerializeField] protected private bool timeToDie = false;

    [SerializeField] protected private bool isEatable = true;

    [SerializeField] protected private string gname = "Entity generated";

    [SerializeField] protected private bool isLive = true;

    [SerializeField] protected private bool isMale = true;//slouží pouze pro zvíøata,ale pro unifikaci tøíd, je to tady

    [SerializeField] protected private List<GameObject> CollisionObject = new List<GameObject>();

    [SerializeField] protected private List<GameObject> myKindSpotted = new List<GameObject>();

    [SerializeField] protected private List<GameObject> plantSpoted = new List<GameObject>();

    [SerializeField] protected private List<GameObject> animalsSpoted = new List<GameObject>();

    [SerializeField] protected private List<GameObject> iWasSpottedBy = new List<GameObject>();

    [SerializeField] protected private List<GameObject> waterSpot = new List<GameObject>();

    [SerializeField] protected private List<GameObject> earthSpot = new List<GameObject>();//only for animals for randomPoint

    [SerializeField] protected float range = 100;

    [SerializeField] protected bool canReproduce = true;//if cooldown_left je roven 0

    [SerializeField] protected float reproduce_cooldown_left = 60;

    [SerializeField] protected float reproduce_cooldown = 60;

    [SerializeField] protected float reproduce_count_children = 0;

    [SerializeField] protected bool poisonous = false;// otrava(body zranìní), pokud se jí rostlina, èi maso jedince

    [SerializeField] protected float hp_poison = 0;//dmg poison pokud není kytka dospìlá

    [SerializeField] protected float hp_poison_notmature = 0;//dmg poison pokud je kytka dospìlá

    [SerializeField] protected TargetCollider targetCollider;

    [SerializeField] protected BodyCollider bodyCollider;
    protected float ReproduceCooldowntToPregnant = 0;          //Odpoèet k porodu
    protected float ReproduceCooldowntToPregnantDefault = 60; // Mezièas, kdy samice nemùže být tìhotná.
    protected private NavMeshAgent agent;

    //potøebuji i prázdné metody start a update, pro pøepsání v potomcích, protože ve výchozím stavu nejsou virtual
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
    }

    public virtual string GetEntityInformation()
    {
        //Metoda, která vrací text. Tento text je využit v oknì s informace o jednotlivci.
        string text = "";
        text += kind + " " + name;
        text += " \n" + CaptionsLibrary.GetCaption("Age") + " " + Mathf.Round(age * 10) / 10 + "\n";
        text += CaptionsLibrary.GetCaption("Adult") + " " + ((isMature) ? CaptionsLibrary.GetCaption("Yes") + " " : CaptionsLibrary.GetCaption("No") + " ") + CaptionsLibrary.GetCaption("AdultInAge") + " " + mature_age + "\n";
        text += (isMale) ? CaptionsLibrary.GetCaption("Male") + " " : CaptionsLibrary.GetCaption("Female");
        text += " \n" + CaptionsLibrary.GetCaption("Animal") + "\n";
        text += (typeEntity == 1) ? (typeEater == 1) ? CaptionsLibrary.GetCaption("Meateater") : (typeEater == 2) ? CaptionsLibrary.GetCaption("Planteater") : CaptionsLibrary.GetCaption("Alleater") : "?";
        text += "\n" + CaptionsLibrary.GetCaption("HP") + " : " + hp + " / " + max_hp + "\n";
        return text;
    }

    public StatisticEntity GetStatisticEntity()
    {
        //Slouží pro ukládání informací v systému statistik.
        return new StatisticEntity(name, kind);
    }

    public new float GetType()
    {
        return type;
    }

    public float GetAge()
    {
        return age;
    }

    public bool GetIsMature()
    {
        if (age < mature_age)
            return false;
        else return true;
    }

    public string GetKind()
    {
        return kind;
    }

    public void SetKind(string _kind)
    {
        kind = _kind;
    }

    public bool GetIsMale()
    {
        return isMale;
    }

    public void SetIsMale(bool gender)
    {
        isMale = gender;
    }

    public float GetHP()
    {
        return hp;
    }

    public string GetName()
    {
        return name;
    }

    public bool GetIsLive()
    {
        return isLive;
    }

    public bool GetIsEatable()
    {
        return isEatable;
    }


    public void ResetReproduceCooldowntToPregnant()
    {
        ReproduceCooldowntToPregnant = ReproduceCooldowntToPregnantDefault;
    }

    public bool GetReproduceCooldowntToPregnant()
    {
        return canReproduce;
    }

    public bool GetCanReproduce()
    {
        return canReproduce;
    }

    public List<GameObject> GetMyKind()
    {
        return myKindSpotted;
    }

    public void SetID(int _id)
    {
        id = _id;
    }

    public void Vypis(string x)
    {
        //Zakomentováno, protože to bylo využito pro testovací úèely
        //V pøípadì odkomentování mùže dojít velice rychle k zahlcení DebugLogu a bude se simulace zasekávat a zpomalovat
        //Debug.Log(name + " > " + x);
    }

    public void GetInCollision(GameObject g)
    {
        //Tato entita se dostala do kolize s G
        if (g.tag == "plant")
        {
            if (!CollisionObject.Contains(g))
                CollisionObject.Add(g);
        }
        //pokud jde o zvíøe a jsem masožrout èi všehožrout
        else if (g.tag == "animal")
        {
            if (!CollisionObject.Contains(g))
                CollisionObject.Add(g);
        }
        else if (g.tag == "water")
        {
            if (!CollisionObject.Contains(g))
                CollisionObject.Add(g);
        }
        else if (this.typeEntity == 1 && g.tag == "terrain")
        {
            if (!CollisionObject.Contains(g))
                CollisionObject.Add(g);
        }
    }

    public void RemoveFromCollision(GameObject g)
    {
        //Entita se dostala z kolize s G
        CollisionObject.Remove(g);
    }

    public bool IsInCollisionWith(GameObject g)
    {
        //Zjištìní, zda entita je v kolizi s objektem G
        Vypis(" jsem v kolizi s " + g.name + " " + CollisionObject.Contains(g).ToString());
        if (CollisionObject.Contains(g))
            return true;
        else return false;
    }

    public void SpottedByWasKilled(GameObject g)
    {
        //Ten, kdo znal tuto entitu, zemøel. Toto slouží k tomu, aby se nevyskytovali nully v seznamech
        Entity e = gameObject.GetComponent<Entity>();
        iWasSpottedBy.Remove(g);
        if (g.tag == "plant")
        {
            plantSpoted.Remove(g);
        }
        else if (g.tag == "animal")
        {
            animalsSpoted.Remove(g);
        }
        if (e.GetKind().Equals(kind))
        {
            myKindSpotted.Remove(g);
        }
    }

    public void GameobjectSpotted(GameObject g)
    {
        //Nìkdo poznal tuto entitu. 
        //https://answers.unity.com/questions/1197626/navmesh-how-to-check-if-full-path-available-c.html
        //vždy jde o entitu, protožen nic jiného se neukládá
        Entity e = null;
        g.TryGetComponent<Entity>(out e);
        if (e != null)
        {
            Entity a = g.GetComponent<Entity>();
            if (!kind.Equals(e.kind))
            {
                if (this.typeEntity == 1)
                {//pokud jsem zvíøe
                    Vypis(" zpozoroval " + a.name + "  " + a.isEatable + " " + e.tag + " " + typeEater + " ");
                    if (a.isEatable)
                    {//pokud jde o zvíøe a jsem všehožrout èi rostlinožrout
                        if (g.tag == "plant" && (this.typeEater == 2 || this.typeEater == 3))
                        {
                            Vypis(" zpozoroval " + g.name);
                            if (!plantSpoted.Contains(g))
                                plantSpoted.Add(g);
                            a.IwasSpottedBy(gameObject);
                        }
                        //pokud jde o zvíøe a jsem masožrout èi všehožrout
                        else if (g.tag == "animal" && (this.typeEater == 1 || this.typeEater == 3))
                        {
                            Vypis(" zpozoroval " + g.name);
                            if (!animalsSpoted.Contains(g))
                                animalsSpoted.Add(g);
                            a.IwasSpottedBy(gameObject);
                        }
                    }
                }
                else if (this.typeEntity == 2)
                {//jenom pokud jde o stejný druh kytky > vymøení pøi urèitém poètu následnì 
                    if (a.GetKind().Equals(this.kind))
                    {
                        if (!plantSpoted.Contains(g))
                            plantSpoted.Add(g);
                        a.IwasSpottedBy(gameObject);
                    }
                }
                else
                {
                    Debug.LogWarning("error typeEntity=0");
                }
            }
            else
            {
                if (!myKindSpotted.Contains(g))
                    myKindSpotted.Add(g);
                a.IwasSpottedBy(gameObject);
            }
        }
        else if (g.tag == "water" && this.typeEntity == 1)
        {//pokud jsem zvíøe a jedná se o bod vody
            if (!waterSpot.Contains(g))
                waterSpot.Add(g);
        }
        else if (this.typeEntity == 1 && g.tag == "terrain" && g.name.Contains("EarthPoint"))
        {//pokud jsem zvíøe a jedná se o bod zemì
            if (!earthSpot.Contains(g))
                earthSpot.Add(g);
        }
    }

    public void IwasSpottedBy(GameObject g)
    {
        //Nìkdo vidìl tuto entitu
        if (!iWasSpottedBy.Contains(g))
            iWasSpottedBy.Add(g);
    }

    public void GameobjectEscaped(GameObject g)
    {
        //nìkdo mi utekl z dohledu
        if (g.tag == "plant")
        {
            plantSpoted.Remove(g);
        }

        else if (g.tag == "animal")
        {
            animalsSpoted.Remove(g);
        }
    }

    public void TakeDMG(float dmg)
    {
        //Dostal jsem zranìní
        hp -= dmg;
        CheckHP();
        Vypis("jsem zranìn +HP: " + hp);
    }

    public float IsEaten(out float dmg)
    {
        //Ten, kdo mì zabil mì právì jí a dostává hodnotu jídla, kterou získává
        //zranìní se udìluje jenom, když se jedná o jedovaté jídlo, èi o nedozrálé jídlo
        if (isMature)
        { dmg = hp_poison_notmature; }
        else
        {
            dmg = hp_poison;
        }
        return foodValue;
    }

    protected private void CheckHP()
    {
        if (hp < 0)
        {
            DieAlready();
        }
    }

    protected private void StatsChangeTimeEntity()
    {
        //Metoda, která se volá každý UPDATE cykl
        if (isLive)
        {
            energy += energy_regen * Time.deltaTime;
            if (energy > max_energy)
                energy = max_energy;
            if (isMature == false)
            {
                //zvìtšuje dítì ve všech mìøítkách, dokud se nedostane na dospìlou velikost;
                gameObject.transform.localScale = new Vector3(
                    gameObject.transform.localScale.x + (0.1f / mature_age) * Time.deltaTime,
                    gameObject.transform.localScale.y + (0.1f / mature_age) * Time.deltaTime,
                    gameObject.transform.localScale.z + (0.1f / mature_age) * Time.deltaTime);
                if (age >= mature_age)
                {
                    isMature = true;
                    if (typeEntity != 2)
                        gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            if (timeToDie == false)
            {
                hp += regen_hp * Time.deltaTime;
                if (hp > max_hp)
                    hp = max_hp;
            }
            else { TakeDMG(Time.deltaTime * 2); }

            age += Time.deltaTime;
            if (age >= ageForDie)
                timeToDie = true;
        }
    }

    protected private void DieAlready()
    {
        if (transform.Find("grp") != null)
        {
            GameObject g = transform.Find("grp").gameObject;
            g.transform.rotation = Quaternion.Euler(-180, 0, 0);
            g.transform.localPosition = new Vector3(g.transform.localPosition.x, g.transform.localPosition.y + 1, g.transform.localPosition.z);
        }
        isLive = false;
        Destroy(gameObject, 20);
    }

    protected private void Wait(float x)
    {
        StartCoroutine(WaitSeconds(x));//Metoda, která slouží pro to, aby entita poèkala nìjaký èas
    }

    protected private IEnumerator WaitSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

    protected private void OnDestroy()
    {
        //metoda, která se volá automaticky enginem, když umírá gameobject
        ClearLists();
        StatisticSystem.IAmDead(this);
    }

    protected private void ClearLists()
    {
        //Èistí se seznamy, aby po umøení entity se nevyskytovali nully v seznamech ostatních entit
        if (iWasSpottedBy.Count! > 0)
            foreach (GameObject item in iWasSpottedBy)
            {
                if (item != null)
                {
                    Entity entity = item.GetComponent<Entity>();
                    entity.SpottedByWasKilled(gameObject);
                }
            }
    }

    protected void Init()
    {
        //Prvotní nastavení bìhem inicializace
        StatisticSystem.IAmLive(this);
        //Zkusí se znièit pøípadný agent a znova vytvoøí. Tento postup slouží pro ovìøení, aby se nestala chyba
        DestroyImmediate(gameObject.GetComponent<NavMeshAgent>());
        agent = gameObject.AddComponent<NavMeshAgent>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        if (this.typeEntity != 2)
        {         //nastaví se prùchozí oblast  
            int areaMask = 1;
            agent.areaMask = areaMask;
        }
        targetCollider = Instantiate(MaterialStorage.TargetCollider, transform.position, Quaternion.identity).GetComponent<TargetCollider>();
        targetCollider.transform.parent = gameObject.transform;
        targetCollider.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f); //new Vector3(0.0f, 0.0f, 0.0f);
        targetCollider.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        targetCollider.transform.localPosition = new Vector3(0, 0, 0);
        targetCollider.SetRange(range);
        targetCollider.SetEntity(this);
        bodyCollider = Instantiate(MaterialStorage.BodyCollidera, transform.position, Quaternion.identity).GetComponent<BodyCollider>();
        bodyCollider.transform.parent = gameObject.transform;
        bodyCollider.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f); //new Vector3(0.0f, 0.0f, 0.0f);
        bodyCollider.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        bodyCollider.transform.localPosition = new Vector3(0, 1, 0);
        if (this is Grass)
        {
            bodyCollider.SetRange(2);
            bodyCollider.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
            bodyCollider.SetRange(30);
        bodyCollider.SetEntity(this);
        bodyCollider.gameObject.layer = (typeEntity == 1) ? 6 : 7;
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        if (typeEntity == 2)
        {
            gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            agent.baseOffset = 0.1f;
        }
        InitHeight2();
        //Nìkdy mùže zlobit agent, kdy nepozná, že se pøesunul k meshi, proto se musí restartovat
        agent.enabled = false;
        agent.enabled = true;

        if (this.typeEntity == 2)
        {  //Agent se u rostlin pøepne na jinou prùchozí oblast. Rostliny s agenty by se jinak pohybovaly.
            try
            {
                int areaMaska = agent.areaMask;
                areaMaska = 4;// NavMesh.GetAreaFromName("Walkable");
                              //areaMaska -= 1 << NavMesh.GetAreaFromName("Jump");//turn on all
                agent.areaMask = areaMaska;
                agent.speed = 0;
                if (agent.isOnNavMesh)
                    agent.isStopped = true;
            }
            catch (System.Exception)
            {
                InitHeight2();
                //Nìkdy mùže zlobit agent, kdy nepozná, že se pøesunul k meshi, proto se musí restartovat
                agent.enabled = false;
                agent.enabled = true;
                int areaMaska = agent.areaMask;
                areaMaska = 4;// NavMesh.GetAreaFromName("Walkable");
                              //areaMaska -= 1 << NavMesh.GetAreaFromName("Jump");//turn on all
                agent.areaMask = areaMaska;
                agent.speed = 0;
                agent.isStopped = true;
            }
            agent.SetDestination(MaterialStorage.Teren[5].transform.position);
        }
    }

    protected bool InitHeight2()
    {
        //slouží pro nastavení výšky. Bohužel hodnì pokus omyl, i když by se to mìlo zvládnout velice brzy
        GameObject pozice, pokus;
        for (int i = 0; i < 1000; i++)
        {
            pokus = MaterialStorage.Teren[Random.Range(1, MaterialStorage.Teren.Count - 1)];
            if (pokus.transform.Find("EarthPoint") != null)
            {
                pozice = pokus.transform.Find("EarthPoint").gameObject;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(pozice.transform.localPosition, out hit, 300.0f, NavMesh.AllAreas))
                {
                    gameObject.transform.position = new Vector3(hit.position.x, hit.position.y, hit.position.z);
                    agent.Warp(new Vector3(hit.position.x, hit.position.y, hit.position.z));
                    return true;
                }
            }
        }
        return false;
    }



    protected void InitHeight()
    {
        //nepoužita a pùvodní metoda
        //Metoda, která slouží pro to, aby pøi vytvoøení entity se nestalo to, že by ta entita nebyla pod terénem, èi nad terénem. 
        //Bohužel není 100% jisté, že se opraví taková chyba.

        int layerMask = 1 << 3;
        RaycastHit hit;
        float lenght = 200;
        // Does the ray intersect any objects excluding the player layer
        Vector3 fromPosition = transform.position;
        Vector3 toPosition = new Vector3(transform.position.x, -100, transform.position.z);
        Vector3 direction = toPosition - fromPosition;
        float min = 1;
        float max = 3;
        if (Physics.Raycast(fromPosition, direction, out hit, lenght, layerMask))
        {//zasáhl a je nad terénem
            if (hit.distance <= max && hit.distance >= min)
            {
                Debug.DrawRay(fromPosition, direction, Color.yellow, 0.5f);
                Debug.Log(gameObject.name + " Did Hit - hit distance :" + hit.distance + "   - object" + hit.collider.gameObject.name);
            }
            else
            {//je moc nad terénem
                Debug.Log(gameObject.name + " Did  Hit - go down - hit distance :" + hit.distance + "   -" + transform.position.ToString());
                float distant = 0;
                if (hit.distance > max)
                {
                    distant = -(hit.distance - max + min);
                }
                else if (hit.distance < min)
                {
                    distant = min;
                }
                transform.position = new Vector3(transform.position.x, transform.position.y + distant, transform.position.z);
                fromPosition = transform.position;
                toPosition = new Vector3(transform.position.x, +100, transform.position.z);
                direction = toPosition - fromPosition;
                if (Physics.Raycast(fromPosition, direction, out hit, lenght, layerMask))
                {
                    if (hit.distance > max)
                    {
                        distant = -(hit.distance - max + min);
                    }
                    else if (hit.distance < min)
                    {
                        distant = min;
                    }
                    transform.position = new Vector3(transform.position.x, transform.position.y + distant, transform.position.z);
                    Debug.Log(gameObject.name + " Did Hit - hit distance :" + hit.distance + "   -" + hit.collider.gameObject.name);
                }
            }
        }
        else
        {
            //gameobject je pod zemí - nezasáhl
            Debug.Log(gameObject.name + " Did not Hit - go top - hit distance :" + hit.distance + "   -" + transform.position.ToString());
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            InitHeight();
        }
    }
}

public enum Entita
{
    Vlk, Ovce, Trava
}
