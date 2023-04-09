using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entity : MonoBehaviour
{
    //Z�kladn� t��da, kterou n�sledn� d�d� zv��ata i rostliny. Spole�n� funkce jsou v t�to t��d�
    [SerializeField] protected private int id = -1;

    [SerializeField] protected private int typeEntity = 0;//1-animal,2-plant, 0 error default;

    [SerializeField] protected private int typeEater = 0;//only for animals 1-meateater,2-planteater,3-alleater;

    [SerializeField] protected private int type = 4;//1-tree,2-plant,3-bush,4-grass;

    [SerializeField] protected private float age = 0;//secs

    [SerializeField] protected private float mature_age = 30;//a� po dosa�en� dosp�losti za�n� ���it semena v okol� jednou za �as

    [SerializeField] protected private bool isMature = false;

    [SerializeField] protected private string kind = "Entity";

    [SerializeField] protected private float hp = 100;

    [SerializeField] protected private float foodValue = 10;

    [SerializeField] protected private float regen_hp = 100;

    [SerializeField] protected private float max_hp = 100;

    [SerializeField] protected private float energy = 0;

    [SerializeField] protected private float energy_regen = 1;//p�i dosa�en� max energy + dosp�lost vyprodukuje jedno sem�nko v okol�

    [SerializeField] protected private float max_energy = 100;

    [SerializeField] protected private float ageForDie = 360;

    [SerializeField] protected private bool timeToDie = false;

    [SerializeField] protected private bool isEatable = true;

    [SerializeField] protected private string gname = "Entity generated";

    [SerializeField] protected private bool isLive = true;

    [SerializeField] protected private bool isMale = true;//slou�� pouze pro zv��ata,ale pro unifikaci t��d, je to tady

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

    [SerializeField] protected bool poisonous = false;// otrava(body zran�n�), pokud se j� rostlina, �i maso jedince

    [SerializeField] protected float hp_poison = 0;//dmg poison pokud nen� kytka dosp�l�

    [SerializeField] protected float hp_poison_notmature = 0;//dmg poison pokud je kytka dosp�l�

    [SerializeField] protected TargetCollider targetCollider;

    [SerializeField] protected BodyCollider bodyCollider;
    protected float ReproduceCooldowntToPregnant = 0;          //Odpo�et k porodu
    protected float ReproduceCooldowntToPregnantDefault = 60; // Mezi�as, kdy samice nem��e b�t t�hotn�.
    protected private NavMeshAgent agent;

    //pot�ebuji i pr�zdn� metody start a update, pro p�eps�n� v potomc�ch, proto�e ve v�choz�m stavu nejsou virtual
    public virtual void Start()
    {
    }

    public virtual void Update()
    {
    }

    public virtual string GetEntityInformation()
    {
        //Metoda, kter� vrac� text. Tento text je vyu�it v okn� s informace o jednotlivci.
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
        //Slou�� pro ukl�d�n� informac� v syst�mu statistik.
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
        //Zakomentov�no, proto�e to bylo vyu�ito pro testovac� ��ely
        //V p��pad� odkomentov�n� m��e doj�t velice rychle k zahlcen� DebugLogu a bude se simulace zasek�vat a zpomalovat
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
        //pokud jde o zv��e a jsem maso�rout �i v�eho�rout
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
        //Zji�t�n�, zda entita je v kolizi s objektem G
        Vypis(" jsem v kolizi s " + g.name + " " + CollisionObject.Contains(g).ToString());
        if (CollisionObject.Contains(g))
            return true;
        else return false;
    }

    public void SpottedByWasKilled(GameObject g)
    {
        //Ten, kdo znal tuto entitu, zem�el. Toto slou�� k tomu, aby se nevyskytovali nully v seznamech
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
        //N�kdo poznal tuto entitu. 
        //https://answers.unity.com/questions/1197626/navmesh-how-to-check-if-full-path-available-c.html
        //v�dy jde o entitu, proto�en nic jin�ho se neukl�d�
        Entity e = null;
        g.TryGetComponent<Entity>(out e);
        if (e != null)
        {
            Entity a = g.GetComponent<Entity>();
            if (!kind.Equals(e.kind))
            {
                if (this.typeEntity == 1)
                {//pokud jsem zv��e
                    Vypis(" zpozoroval " + a.name + "  " + a.isEatable + " " + e.tag + " " + typeEater + " ");
                    if (a.isEatable)
                    {//pokud jde o zv��e a jsem v�eho�rout �i rostlino�rout
                        if (g.tag == "plant" && (this.typeEater == 2 || this.typeEater == 3))
                        {
                            Vypis(" zpozoroval " + g.name);
                            if (!plantSpoted.Contains(g))
                                plantSpoted.Add(g);
                            a.IwasSpottedBy(gameObject);
                        }
                        //pokud jde o zv��e a jsem maso�rout �i v�eho�rout
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
                {//jenom pokud jde o stejn� druh kytky > vym�en� p�i ur�it�m po�tu n�sledn� 
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
        {//pokud jsem zv��e a jedn� se o bod vody
            if (!waterSpot.Contains(g))
                waterSpot.Add(g);
        }
        else if (this.typeEntity == 1 && g.tag == "terrain" && g.name.Contains("EarthPoint"))
        {//pokud jsem zv��e a jedn� se o bod zem�
            if (!earthSpot.Contains(g))
                earthSpot.Add(g);
        }
    }

    public void IwasSpottedBy(GameObject g)
    {
        //N�kdo vid�l tuto entitu
        if (!iWasSpottedBy.Contains(g))
            iWasSpottedBy.Add(g);
    }

    public void GameobjectEscaped(GameObject g)
    {
        //n�kdo mi utekl z dohledu
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
        //Dostal jsem zran�n�
        hp -= dmg;
        CheckHP();
        Vypis("jsem zran�n +HP: " + hp);
    }

    public float IsEaten(out float dmg)
    {
        //Ten, kdo m� zabil m� pr�v� j� a dost�v� hodnotu j�dla, kterou z�sk�v�
        //zran�n� se ud�luje jenom, kdy� se jedn� o jedovat� j�dlo, �i o nedozr�l� j�dlo
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
        //Metoda, kter� se vol� ka�d� UPDATE cykl
        if (isLive)
        {
            energy += energy_regen * Time.deltaTime;
            if (energy > max_energy)
                energy = max_energy;
            if (isMature == false)
            {
                //zv�t�uje d�t� ve v�ech m���tk�ch, dokud se nedostane na dosp�lou velikost;
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
        StartCoroutine(WaitSeconds(x));//Metoda, kter� slou�� pro to, aby entita po�kala n�jak� �as
    }

    protected private IEnumerator WaitSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

    protected private void OnDestroy()
    {
        //metoda, kter� se vol� automaticky enginem, kdy� um�r� gameobject
        ClearLists();
        StatisticSystem.IAmDead(this);
    }

    protected private void ClearLists()
    {
        //�ist� se seznamy, aby po um�en� entity se nevyskytovali nully v seznamech ostatn�ch entit
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
        //Prvotn� nastaven� b�hem inicializace
        StatisticSystem.IAmLive(this);
        //Zkus� se zni�it p��padn� agent a znova vytvo��. Tento postup slou�� pro ov��en�, aby se nestala chyba
        DestroyImmediate(gameObject.GetComponent<NavMeshAgent>());
        agent = gameObject.AddComponent<NavMeshAgent>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        if (this.typeEntity != 2)
        {         //nastav� se pr�choz� oblast  
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
        //N�kdy m��e zlobit agent, kdy nepozn�, �e se p�esunul k meshi, proto se mus� restartovat
        agent.enabled = false;
        agent.enabled = true;

        if (this.typeEntity == 2)
        {  //Agent se u rostlin p�epne na jinou pr�choz� oblast. Rostliny s agenty by se jinak pohybovaly.
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
                //N�kdy m��e zlobit agent, kdy nepozn�, �e se p�esunul k meshi, proto se mus� restartovat
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
        //slou�� pro nastaven� v��ky. Bohu�el hodn� pokus omyl, i kdy� by se to m�lo zvl�dnout velice brzy
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
        //nepou�ita a p�vodn� metoda
        //Metoda, kter� slou�� pro to, aby p�i vytvo�en� entity se nestalo to, �e by ta entita nebyla pod ter�nem, �i nad ter�nem. 
        //Bohu�el nen� 100% jist�, �e se oprav� takov� chyba.

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
        {//zas�hl a je nad ter�nem
            if (hit.distance <= max && hit.distance >= min)
            {
                Debug.DrawRay(fromPosition, direction, Color.yellow, 0.5f);
                Debug.Log(gameObject.name + " Did Hit - hit distance :" + hit.distance + "   - object" + hit.collider.gameObject.name);
            }
            else
            {//je moc nad ter�nem
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
            //gameobject je pod zem� - nezas�hl
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
