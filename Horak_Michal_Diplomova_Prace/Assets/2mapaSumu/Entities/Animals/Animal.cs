using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Animal : Entity
{

    [SerializeField] private Stav stav = Stav.Nothing;
    [SerializeField] private float hunger = 65;
    [SerializeField] private float max_hunger = 100;
    [SerializeField] private float hunger_perSec = 0.3f;
    [SerializeField] private float thirsty = 0;
    [SerializeField] private float max_thirsty = 100;
    [SerializeField] private float thirsty_perSec = 0.3f;
    [SerializeField] private float sleepnes = 65;
    [SerializeField] private float max_sleepnes = 100;
    [SerializeField] private float sleepnes_perSec = 0.3f;
    [SerializeField] private float strenght = 20;
    public void SetTimeHunger(float value) { hunger_perSec = value; }
    public void SetTimeThirsty(float value) { thirsty_perSec = value; }
    public void SetTimeSleep(float value) { sleepnes_perSec = value; }
    public void SetStrenght(float value) { strenght = value; }
    [SerializeField] private bool isPregnant = false;
    public void SetIsPregnant(bool pregnancy) { isPregnant = pregnancy; }
    public bool GetIsPregnant() { return isPregnant; }
    [SerializeField] private float pregnancyTimeToBornDefault = 120.0f;
    [SerializeField] private float pregnancyTimeToBorn = 120.0f;
    public void ResetTimePregnancy() { pregnancyTimeToBorn = pregnancyTimeToBornDefault; }
    public float GetTimePregnancy() { return pregnancyTimeToBorn; }
    public void SetTimePregnancyDefault(float time) { pregnancyTimeToBornDefault = time; }
    [SerializeField] private bool isRunning = false;
    [SerializeField] private bool isTargeted = false;
    [SerializeField] private float targetRange = 2.0f;
    [SerializeField] private GameObject target = null;
    [SerializeField] private GameObject lasttarget = null;//pro zji�t�n�, zda lov�m st�le jednu ko�ist
    [SerializeField] private GameObject targetAttackingMe = null;

    [SerializeField] private GameObject targetAttackingPartner = null;
    [SerializeField] private GameObject targetRandomTerrain = null;
    [SerializeField] private GameObject targetWater = null;
    [SerializeField] private GameObject targetFood = null;
    [SerializeField] private float partnerMaxRange = 20.0f;

    public GameObject GetTargetWater() { return targetWater; }
    public float GetPartnerMaxRange { get { return partnerMaxRange; } }

    public void SetPartnerMaxRange(float _range) { partnerMaxRange = _range; }
    public GameObject GetTargetAttackingMe { get { return targetAttackingMe; } }

    public void SetTargetAttackingMe(Entity enemy) { targetAttackingMe = enemy.gameObject; }
    public GameObject GetTargetAttackingPartner { get { return targetAttackingPartner; } }

    public void SetTargetAttackingPartner(Entity enemy) { targetAttackingPartner = enemy.gameObject; }
    public GameObject GetPartner { get { return partner; } }

    public void SetPartner(Entity _NewPartner) { partner = _NewPartner.gameObject; }
    [SerializeField] private GameObject partner = null;
    [SerializeField] private GameObject father = null, mother = null;
    [SerializeField] private List<GameObject> childrens = new List<GameObject>();
    public void AddChilren(Entity children) { if (!childrens.Contains(children.gameObject)) childrens.Add(children.gameObject); }
    public void RemoveChildren(Entity child) { childrens.Remove(child.gameObject); }



    //for radar decision
    //zm�nit na mno�iny
    [SerializeField] protected private List<GameObject> foodSpoted = new List<GameObject>();


    [SerializeField] private List<GameObject> plantspoted = new List<GameObject>();

    [SerializeField] private List<GameObject> TheyAreGoForMe = new List<GameObject>();

    [SerializeField] private GameObject closestWaterSpot = null;
    [SerializeField] private GameObject closestAnimalSpot = null;
    [SerializeField] private GameObject closestPlantSpot = null;

    public Stav GetStav { get { return stav; } }
    public void SetStav(Stav _stav)
    {
        Vypis("jdu na ze stavu " + stav.ToString() + " na " + _stav.ToString());


        stav = _stav;
    }
    public void SetStav(Stav _stav, bool resetRandomTarget)
    {
        Vypis("jdu na ze stavu " + stav.ToString() + " na " + _stav.ToString());

        if (this.stav == Stav.GoRandom && _stav != Stav.GoRandom && resetRandomTarget == true)
        { ResetRandomPointTarget(); }
        stav = _stav;
    }




    [SerializeField] private TopSelector topNode;


    private void ConstructBehahaviourTree()
    {

        NodeGoTo goNode = new NodeGoTo(agent, this);
        NodeIsInRange isInRangeNode = new NodeIsInRange(this, targetRange);
        Sequence goSequence = new Sequence(new List<Node> { new Inverter(isInRangeNode), goNode });

        IsLive isLiveNode = new IsLive(this);
        Attack attackNode = new Attack(agent, this);
        Sequence AttackSequence = new Sequence(new List<Node> { isLiveNode, isInRangeNode, attackNode });

        Selector goOrFight = new Selector(new List<Node>
            { new Selector(new List<Node> { AttackSequence, goSequence })
           });
        //#################################################################################//
        //########################        osobn� pot�eby        ###########################//
        //#################################################################################//

        Sleep sleepNode = new Sleep(agent, this);
        NeedSleep needSleepNode = new NeedSleep(this);


        Eat eatNode = new Eat(agent, this);
        NeedEat needEatNode = new NeedEat(this);

        Sequence eatSequence = new Sequence(new List<Node> { new Inverter(isLiveNode), isInRangeNode, eatNode });
        Selector selectEatAttack = new Selector(new List<Node> { AttackSequence, eatSequence });
        // Sequence hungerSequence = new Sequence("eat",10,new List<Node> { needEatNode, goSequence, AttackSequence, eatSequence });
        // Sequence hungerSequence = new Sequence("Food eat", 10, new List<Node> { needEatNode, goSequence, selectEatAttack });
        //Sequence hungerSequence = new Sequence("Food eat", 10, new List<Node> { needEatNode, goOrFight });

        Sequence hungerSequence = new Sequence("eat", 10,
            new List<Node> { needEatNode, new Selector(new List<Node>
            { new Selector(new List<Node> { new Sequence("eat/attack",10,new List<Node> { isInRangeNode, selectEatAttack }), goSequence })
           })  });


        Drink drinkNode = new Drink(agent, this);
        NeedDrink needDrink = new NeedDrink(this);
        Sequence drinkingS = new Sequence(new List<Node> { isInRangeNode, drinkNode });
        Sequence goForWaterSequence = new Sequence(new List<Node> { new Inverter(isInRangeNode), goNode });
        Sequence drinkSequence = new Sequence("drink", 11, new List<Node> { needDrink, goSequence, drinkNode });

        Sequence sleepSequence = new Sequence("sleep", 12, new List<Node> { needSleepNode, sleepNode });

        NeedDefend needDefend = new NeedDefend(this);
        Sequence needDefendSequence = new Sequence("need def", 5, new List<Node> { needDefend, goSequence });


        //#################################################################################//
        //########################      soci�ln� pot�eby        ###########################//
        //#################################################################################//
        FindPartner findPartner = new FindPartner(this);


        NodeGoTo goNode2 = new NodeGoTo(agent, this);
        NodeIsInRange isInRangeNode2 = new NodeIsInRange(this, targetRange);
        Selector selectRightWay = new Selector(new List<Node> { new Sequence(new List<Node> { isInRangeNode2, goNode2 }), new Sequence(new List<Node> { new Inverter(isInRangeNode2), goNode2 }) });
        Sequence goSequence2 = new Sequence(new List<Node> { selectRightWay });

        FollowPartner followPartner = new FollowPartner(this, partnerMaxRange);
        Sequence FolowPartnerSequence = new Sequence("follow", 99, new List<Node> { followPartner, goSequence2 });

        IsPartnerUnderAttack isPartnerUnderAttack = new IsPartnerUnderAttack(this);
        Sequence isPartnerUnderAttackSequence = new Sequence("def partner", 6, new List<Node> { isPartnerUnderAttack, goOrFight });


        SelectRandomPoint selectRandomPoint = new SelectRandomPoint(this);
        Sequence GoRandomPointSequence = new Sequence("GoRandom", 100, new List<Node> { selectRandomPoint, goNode });


        if (!isMale)
        {

            TimeToBorn timeToBorn = new TimeToBorn(this);
            topNode = new TopSelector(this, 0, new List<Node> { timeToBorn, needDefendSequence, isPartnerUnderAttackSequence, findPartner }, new List<Node> { hungerSequence, drinkSequence, sleepSequence }, new List<Node> { FolowPartnerSequence, GoRandomPointSequence });
        }
        else
        {
            Sequence MakeBabySequence = new Sequence("Make baby", 99, new List<Node> { new PartnerIsReadForChildren(this), goSequence2, new MakeChildren(this) });
            topNode = new TopSelector(this, 0, new List<Node> { needDefendSequence, isPartnerUnderAttackSequence, findPartner }, new List<Node> { hungerSequence, drinkSequence, sleepSequence }, new List<Node> { MakeBabySequence, GoRandomPointSequence });

            //make baby
        }

    }
    public override void Start()
    {

        Init();
        //   InitHeight2();
        //  kind = "animal";
        //  typeEater = 2;//only for animals 1-meateater,2-planteater,3-alleater;
        if (TryGetComponent(out NavMeshAgent ag))
        {
            typeEntity = 1;
            agent = ag;



        }
        else
        {
            agent = gameObject.AddComponent<NavMeshAgent>();
        }

        gameObject.GetComponentInChildren<TargetCollider>().SetEntity(this);
        gameObject.GetComponentInChildren<TargetCollider>().SetRange(range);
        ConstructBehahaviourTree();
    }
    //  Vypis(agent.destination.ToString());

    public void InitHeightReset()
    { InitHeight2(); }
    private bool IsPositionEquel(Vector3 a, Vector3 b)
    {
        if (a == b)
            return true;
        else return false;
    }
    public override void Update()
    {



        if ((isLive && hp > 0))
        {
            // setAgentMovementEnabled(true);
            StatsChangeTimeEntity();
            StatsChangeAnimal();
            NodeState state = topNode.Evaluate();
            Vypis(topNode.Vypis());
            // initHeight();
        }

        else if (!isLive && hp < 0)
        {
            SetAgentMovementEnabled(true);
            gameObject.transform.Rotate(-1f, -1f, -1f);
        }
        //  Wait(0.5f);
    }
    private void StatsChangeAnimal()
    {
        hunger += Time.deltaTime * hunger_perSec;
        if (hunger >= max_hunger)
        {
            hunger = max_hunger;
        }
        thirsty += Time.deltaTime * thirsty_perSec;
        if (thirsty >= max_thirsty)
        {
            thirsty = max_thirsty;
        }
        sleepnes += Time.deltaTime * hunger_perSec;
        if (sleepnes >= max_sleepnes)
        {
            sleepnes = max_sleepnes;
        }
        if (!isMale && isPregnant)
        {
            pregnancyTimeToBorn -= Time.deltaTime;
        }
        if (!isMale && !isPregnant)
        {
            if (ReproduceCooldowntToPregnant > 0)
            {
                ReproduceCooldowntToPregnant -= Time.deltaTime;
                if (ReproduceCooldowntToPregnant <= 0)
                { ReproduceCooldowntToPregnant = 0; }
            }
            else
            {
                canReproduce = true;
            }
        }
    }
    private void SwitchWalkableLayer(bool x)
    {
        if (x == false)
        {
            int areaMask = agent.areaMask;

            // areaMask -= 1 << NavMesh.GetAreaFromName("Walkable");
            areaMask = 4;//NavMesh.GetAreaFromName("Jump");//turn on all
            agent.areaMask = areaMask;
            //  Debug.LogError("no");
            // agent.SetDestination(new Vector3 (15,transform.position.y,15));
        }
        else
        {
            int areaMask = agent.areaMask;
            areaMask = 1;// NavMesh.GetAreaFromName("Walkable");
            //  areaMask -= 1 << NavMesh.GetAreaFromName("Jump");//turn on all
            agent.areaMask = areaMask;
            //       Debug.LogError("ok");
        }
    }



    public float GetStrenght() { return strenght; }

    public bool GetIsRunning() { return isRunning; }
    public bool GetIsTargeted() { return isTargeted; }
    public float GetSleep() { return sleepnes; }
    public float GetSleepMax() { return max_sleepnes; }
    public float GetHunger() { return hunger; }
    public float GetHugerMax() { return max_hunger; }
    public float GetThirsty() { return thirsty; }
    public float GetThirstyMax() { return max_thirsty; }
    public void TheyAreGoForMyMeat(GameObject g)
    {
        if (!TheyAreGoForMe.Contains(g))
            TheyAreGoForMe.Add(g);

    }
    public void TheyAreNoGoForMyMeatLonger(GameObject g)
    {
        TheyAreGoForMe.Remove(g);
    }
    private void IGoForYourMeat()
    {
        if (targetFood.tag == "animal")
        {
            if (targetFood == lasttarget)
            { targetFood.GetComponent<Animal>().TheyAreGoForMyMeat(gameObject); }
            else if (targetFood != lasttarget)
            {
                targetFood.GetComponent<Animal>().TheyAreGoForMyMeat(gameObject);
                lasttarget.GetComponent<Animal>().TheyAreNoGoForMyMeatLonger(gameObject);
                lasttarget = targetFood;
            }
        }

    }

    private void ActualyCloseAnimal()
    {
        GameObject close = null;
        float distance = int.MaxValue - 2;
        float distanceTemp = int.MaxValue;
        foreach (GameObject item in animalsSpoted)
        {
            if (close == null)
            {
                close = item;
                distance = Vector3.Distance(gameObject.transform.position, item.transform.position);
                //    if(closestAnimalSpot!=null)
                //    Vypis("closesttargetfood" + closestAnimalSpot.name);
            }
            else
            {

                distanceTemp = Vector3.Distance(gameObject.transform.position, item.transform.position);
                if (distanceTemp < distance)
                {
                    distance = distanceTemp;
                    close = item;
                    //  if (closestAnimalSpot != null)
                    //    Vypis("closesttargetfood" + closestAnimalSpot.name);
                }
            }
        }
        closestAnimalSpot = close;
        // if (closestAnimalSpot != null)
        //    Vypis("closesttargetfood" + closestAnimalSpot.name);

    }
    private void ActualyClosePlant()
    {
        GameObject close = null;
        float distance = int.MaxValue - 2;
        float distanceTemp = int.MaxValue;
        foreach (GameObject item in plantspoted)
        {
            if (close == null)
            {
                close = item;
                distance = Vector3.Distance(gameObject.transform.position, item.transform.position);
            }
            else
            {

                distanceTemp = Vector3.Distance(gameObject.transform.position, item.transform.position);
                if (distanceTemp < distance)
                {
                    distance = distanceTemp;
                    close = item;
                }
            }
        }
        closestPlantSpot = close;
    }
    private void ActualyCloseWater()
    {
        GameObject close = null;
        float distance = int.MaxValue - 2;
        float distanceTemp = int.MaxValue;
        foreach (GameObject item in waterSpot)
        {
            if (close == null)
            {
                close = item;
                distance = Vector3.Distance(gameObject.transform.position, item.transform.position);
            }
            else
            {

                distanceTemp = Vector3.Distance(gameObject.transform.position, item.transform.position);
                if (distanceTemp < distance)
                {
                    distance = distanceTemp;
                    close = item;
                }
            }
        }
        closestWaterSpot = close;

    }
    public void CloseWater()
    {
        ActualyCloseWater();
        if (targetWater != closestWaterSpot && closestWaterSpot != null)
        {

            targetWater = closestWaterSpot;
        }
    }
    public void CloseFood()
    {
        //  Vypis(animalsSpoted.Count.ToString()+"|"+type);
        //type ;//1-meateater,2-planteater,3-alleater;
        if (typeEater == 1)
        {
            //    Vypis("food" );
            ActualyCloseAnimal();
            targetFood = closestAnimalSpot;
            //    Vypis("targetfood22" + targetFood.name);
        }
        else if (typeEater == 2)
        {
            //     Vypis("food");
            ActualyClosePlant();
            targetFood = closestPlantSpot;
        }
        else if (typeEater == 3)
        {
            //   Vypis("food");
            ActualyCloseAnimal();
            ActualyClosePlant();

            if (closestAnimalSpot != null && closestPlantSpot == null)
            {
                targetFood = closestAnimalSpot;
                //     Vypis("targetfood22" + targetFood.name);
                return;
            }
            if (closestAnimalSpot == null && closestPlantSpot != null)
            {
                targetFood = closestPlantSpot;
                //   Vypis("targetfood22" + targetFood.name);
                return;
            }
            if (closestAnimalSpot != null && closestPlantSpot != null)
            {
                float distanceAnimal = Vector3.Distance(gameObject.transform.position, closestAnimalSpot.transform.position);
                float distancePlant = Vector3.Distance(gameObject.transform.position, closestPlantSpot.transform.position);


                if (distanceAnimal < distancePlant)
                {
                    targetFood = closestAnimalSpot;
                }
                else
                {
                    targetFood = closestPlantSpot;
                }
                Vypis("targetfood22" + targetFood.name);
                return;
            }

        }
    }




    public bool CalculateNewPath(Vector3 target)
    {
        bool wasstate = agent.enabled;
        agent.enabled = true;
        Vector3 novy = new Vector3(target.x, target.y - 0.2f, target.z);
        NavMeshPath navMeshPath = new NavMeshPath();
        agent.CalculatePath(novy, navMeshPath);
        agent.enabled = wasstate;
        if (navMeshPath.status != NavMeshPathStatus.PathComplete)
        {
            //    Debug.Log("cesta nenalezena");
            return false;
        }
        else
        {//  Debug.Log("New path calculated");
            return true;
        }
    }

    public void SetTarget(GameObject g)
    {
        if (target == null)
        {
            if (g.gameObject.tag == "animal")
            {

                if (!target.GetComponent<Animal>().GetKind().Equals(GetKind()))
                {
                    target = g.gameObject;
                    Debug.Log("Target located" + g.gameObject.name);
                }
                else
                {
                    Debug.Log("Target  kanibalismus");
                }
                // target = g.gameObject;
                // Debug.Log("Target located" + g.gameObject.name);
            }


        }
        else
        {

            if (g.gameObject.tag == "animal")
            {

                if (!target.GetComponent<Animal>().GetKind().Equals(GetKind()))
                {   //implementovat to , kdy� c�l je bl�
                    target = g.gameObject;
                    Debug.Log("Target located" + g.gameObject.name);
                }
                else
                {
                    Debug.Log("Target  kanibalismus");
                }

            }
        }
    }

    public void Sleep()
    {


        sleepnes -= 50 * Time.deltaTime;
        if (sleepnes < 0)
            sleepnes = 0;
    }
    public void Eat(Entity entity)
    {
        float foodValue = entity.IsEaten(out float dmg);
        hunger -= foodValue;
        targetFood = null;
        TakeDMG(dmg);
    }

    public float GetHungerPercentage() { return (GetHunger() / GetHugerMax()); }
    public float GetThirstyPercentage() { return (GetThirsty() / GetThirstyMax()); }
    public float GetSlePercentage() { return (GetSleep() / GetSleepMax()); }

    public void Drink()
    {

        thirsty -= 50 * Time.deltaTime;
        if (thirsty < 0)
            thirsty = 0;
        if (GetThirsty() / GetThirstyMax() < 0.1)
        { targetWater = null; }

    }
    public float GetDistanceToTarget()
    {
        if ((stav == Stav.GoingForFood || stav == Stav.Eating || stav == Stav.GoingForFight) && targetFood != null)
        {
            CloseFood();
            if (targetFood != null)
                return Vector3.Distance(gameObject.transform.position, targetFood.transform.position);


            else return -1000;
        }
        else if ((stav == Stav.GoingForPlace || stav == Stav.Going) && target != null)
        {

            if (target != null)
                return Vector3.Distance(gameObject.transform.position, target.transform.position);
            else return -1000;
        }
        else if ((stav == Stav.Drinking || stav == Stav.GoingForWater) && targetWater != null)
        {
            CloseWater();
            if (targetWater != null)
                return Vector3.Distance(gameObject.transform.position, targetWater.transform.position);
            else return -1000;
        }
        else if (stav == Stav.GoingforDefend)
        {
            if (GetAttackingMeClosestEntity() != null)
                return Vector3.Distance(gameObject.transform.position, GetAttackingMeClosestEntity().transform.position);
            else return -1000;
        }
        else if (stav == Stav.GoingforDefend)
        {
            if (GetAttackingPartnerClosestEntity() != null)
                return Vector3.Distance(gameObject.transform.position, GetAttackingPartnerClosestEntity().transform.position);
            else return -1000;
        }
        else if (stav == Stav.FollowParty)
        {
            if (partner != null)
                return Vector3.Distance(gameObject.transform.position, partner.transform.position);
            else if (father != null)
                return Vector3.Distance(gameObject.transform.position, father.transform.position);
            else if (mother != null)
                return Vector3.Distance(gameObject.transform.position, mother.transform.position);
            else return -1000;
        }
        else if (stav == Stav.GoRandom)
        {
            if (targetRandomTerrain != null)
            {

                return Vector3.Distance(gameObject.transform.position, targetRandomTerrain.transform.position);
            }
            else return -1000;
        }
        else if (stav == Stav.Mating)
        {
            if (partner != null)
            {

                return Vector3.Distance(gameObject.transform.position, partner.transform.position);
            }
            else return -1000;
        }
        else if (stav == Stav.Nothing)
        {
            Vypis("pt� se po c�li a nic ned�l�!!");
            return -1000;
        }
        else return -1000;
    }
    public GameObject GetTarget()
    {
        if ((stav == Stav.Eating || stav == Stav.GoingForFood || stav == Stav.GoingForFight) && targetFood != null)
        {
            CloseFood();

            if (targetFood != null)
                return targetFood;
            else return null;
        }
        else if ((stav == Stav.GoingForPlace || stav == Stav.Going) && target != null)
        {
            if (target != null)
                return target;
            else return null;
        }
        else if ((stav == Stav.Drinking || stav == Stav.GoingForWater) && targetWater != null)
        {
            CloseWater();
            if (targetWater != null)
                return targetWater;
            else return null;
        }
        else if (stav == Stav.GoingforDefend)
        {
            if (GetAttackingMeClosestEntity() != null)
                return GetAttackingMeClosestEntity();
            else return null;
        }
        else if (stav == Stav.GoingforDefend)
        {
            if (GetAttackingPartnerClosestEntity() != null)
                return GetAttackingPartnerClosestEntity();
            else return null;
        }
        else if (stav == Stav.FollowParty)
        {
            if (partner != null)
                return partner;
            else if (father != null)
                return father;
            else if (mother != null)
                return mother;
            else return null;
        }
        else if (stav == Stav.GoRandom)
        {
            if (targetRandomTerrain != null)
                return targetRandomTerrain;
            else return null;
        }
        else if (stav == Stav.Mating)
        {
            if (partner != null)
                return partner;
            else return null;
        }
        //u� neplat� //pro jistotu target a ne null....
        else return null;
    }
    public Entity GetFoodTarget()
    {
        if (targetFood == null)
        {
            return null;
        }
        targetFood.TryGetComponent<Animal>(out Animal a);
        if (a != null)
            return a;
        else
        {
            targetFood.TryGetComponent<Plant>(out Plant p);
            if (p != null)
                return p;
            else
            {
                Vypis("cil k sezrani nenalezen"); return null;
            }
        }

    }

    public void GetStavNext()
    {
        if (stav == Stav.GoingForFood)
        {
            stav = Stav.Eating;
        }
        else if (stav == Stav.GoingForPlace)
        {
            stav = Stav.Nothing;
        }
        else if (stav == Stav.GoingForFight)
        {
            stav = Stav.Attacking;
        }
        if (stav == Stav.GoingForWater)
        {
            stav = Stav.Drinking;
        }

    }


    Vector3 vektor;
    public void SetAgentMovementEnabled(bool x)
    {
        if (agent.enabled == true)
        {
            if (x == true)
            {
                SwitchWalkableLayer(false);
            }
            else
            {
                SwitchWalkableLayer(true);
            }

            agent.isStopped = x;


        }
    }
    public GameObject GetAttackingMeClosestEntity()
    {//ke m� nejbli��� nep��tel,co m� napad�;
        GameObject closest = null;
        float distance = int.MaxValue;
        foreach (GameObject item in TheyAreGoForMe)
        {
            if (closest == null)
                closest = item;
            else
            {
                float distanceNew = Vector3.Distance(gameObject.transform.position, item.transform.position);
                if (distanceNew < distance)
                {
                    distance = distanceNew;
                    closest = item;
                }
            }

        }

        targetAttackingMe = closest;
        return targetAttackingMe;
    }
    public GameObject GetAttackingPartnerClosestEntity()
    {//Ke m� nejbli��� nep��tel,co napad� partnera
        if (partner != null)
        {
            GameObject closest = null;
            float distance = int.MaxValue;
            foreach (GameObject item in partner.GetComponent<Animal>().TheyAreGoForMe)
            {
                if (closest == null)
                    closest = item;
                else
                {
                    float distanceNew = Vector3.Distance(gameObject.transform.position, item.transform.position);
                    if (distanceNew < distance)
                    {
                        distance = distanceNew;
                        closest = item;
                    }
                }

            }

            targetAttackingPartner = closest;
            return targetAttackingPartner;
        }
        else return null;
    }

    public bool IsOneOfState(List<Stav> povoleneStavy)
    {
        if (povoleneStavy != null)
        {
            foreach (Stav item in povoleneStavy)
            {
                if (item == this.stav)
                    return true;
            }
            return false;
        }
        return false;
    }
    public GameObject SetRandomPointTarget()
    {
        if (earthSpot.Count != 0)
        {

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    GameObject g = earthSpot[Mathf.RoundToInt(Random.Range(0, earthSpot.Count))];
                    targetRandomTerrain = g;
                    Vypis("set bod " + g.name);
                    return targetRandomTerrain;
                }
                catch (System.Exception)
                {


                }
            }

            Vypis("nenalezen vhodn� bod");
            //nelezeno nic vhodn�ho
            return null;
        }//pr�zdn� seznam

        else
        {
            Vypis("��dn�  bod");
            return null;
        }

    }
    public GameObject GetRandomPointTarget()
    {
        return targetRandomTerrain;
    }
    public void ResetRandomPointTarget()
    {
        targetRandomTerrain = null;
    }

    public override string GetEntityInformation()
    {
        string text = "";
        //   Debug.LogWarning("Info");
        text += kind + " " + name;
        text += " \n" + CaptionsLibrary.GetCaption("Age") + " " + Mathf.Round(age * 10) / 10 + "\n";
        text += CaptionsLibrary.GetCaption("Adult") + " " + ((isMature) ? CaptionsLibrary.GetCaption("Yes") + " " : CaptionsLibrary.GetCaption("No") + " ") + CaptionsLibrary.GetCaption("AdultInAge") + " " + mature_age + "\n";
        text += (isMale) ? CaptionsLibrary.GetCaption("Male") + " " : CaptionsLibrary.GetCaption("Female");
        text += " \n" + CaptionsLibrary.GetCaption("Animal") + "\n";
        text += (typeEntity == 1) ? (typeEater == 1) ? CaptionsLibrary.GetCaption("Meateater") : (typeEater == 2) ? CaptionsLibrary.GetCaption("Planteater") : CaptionsLibrary.GetCaption("Alleater") : "?";
        text += "\n" + CaptionsLibrary.GetCaption("HP") + " : " + hp + " / " + max_hp + "\n";
        text += CaptionsLibrary.GetCaption("Hungery") + ": " + Mathf.Round((hunger / max_hunger) * 1000) / 1000 + "\n";
        text += CaptionsLibrary.GetCaption("Thirsty") + ": " + Mathf.Round((thirsty / max_thirsty) * 1000) / 1000 + "\n";
        text += CaptionsLibrary.GetCaption("Sleep") + ": " + Mathf.Round((sleepnes / max_sleepnes) * 1000) / 1000 + "\n";
        text += (isMale) ? "" : (isPregnant) ? (CaptionsLibrary.GetCaption("PregnantYes") + pregnancyTimeToBorn + "\n") : CaptionsLibrary.GetCaption("PregnantNo") + "\n";
        string par, otec, matka, potomci = "";
        if (partner != null)
        { par = partner.name; }
        else par = CaptionsLibrary.GetCaption("Dead");
        if (father != null)
        { otec = father.name; }
        else otec = CaptionsLibrary.GetCaption("Dead");
        if (mother != null)
        { matka = mother.name; }
        else matka = CaptionsLibrary.GetCaption("Dead");

        if (childrens.Count != 0)
        {
            foreach (GameObject item in childrens)
            {
                potomci += " " + gameObject.name + ", ";

            }
        }
        else potomci = CaptionsLibrary.GetCaption("None");
        text += (isMale) ? CaptionsLibrary.GetCaption("FemalePartner") + " " + par : CaptionsLibrary.GetCaption("MalePartner") + " " + par;


        text += "\n" + CaptionsLibrary.GetCaption("Father") + " : " + otec + "\n";
        text += CaptionsLibrary.GetCaption("Mother") + " : " + matka + "\n";
        text += CaptionsLibrary.GetCaption("Children") + " : " + potomci + "\n";
        text += CaptionsLibrary.GetCaption("State") + " : " + CaptionsLibrary.GetCaption(stav) + "\n";
        return text;
    }


}


public enum Stav
{
    Going, Sleeping, Eating, Drinking, Attacking, Mating, Nothing, Relax, GoingForWater, GoingForFood, GoingForPlace, GoingForFight, GoingforDefend, GoingforDefendPartner, FollowParty, GoRandom,
}