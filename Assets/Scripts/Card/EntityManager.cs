using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Inst {get; private set;}
    void Awake() => Inst = this;

    [SerializeField] EnemySO enemyso;
    [SerializeField] Transform EnemySpawnPointLeft;
    [SerializeField] Transform EnemySpawnPointRight;
    [SerializeField] List<Entity> myEntities;
    [SerializeField] List<Entity> EnemyEntities;
    [SerializeField] CardManager cardManager;

    public bool isSpawn;
    public float spawnDelay = 1.5f;
    float spawnTimer = 0f;

    public void SpawnEntity(Item item, Vector3 spawnPos){
        var entityObject = Instantiate(item.prefabs, spawnPos, Utils.QI);
        var entity = entityObject.GetComponent<Entity>();
        entity.Setup(item);
        entity.thisentity = entityObject;
        myEntities.Add(entity);
    }

    public void SpawnEnemy(EnemySO enemyso){

        Enemy[] enemies = enemyso.enemies;
        
        if(isSpawn == true)
        {
            if (spawnTimer > spawnDelay)
            {
                if (EnemyEntities.Count < 5)
                {
                    Enemy randenemy = enemies[Random.Range(0, enemies.Length - 2)];
                    var enemyObject = Instantiate(randenemy.prefabs, EnemySpawnPointRight.position, Utils.QI);
                    var enemyentity = enemyObject.GetComponent<Entity>();
                    enemyentity.SetupEnemy(randenemy);
                    enemyentity.thisentity = enemyObject;
                    EnemyEntities.Add(enemyentity);
                    spawnTimer = 0f;
                
                }
            }

            spawnTimer += Time.deltaTime;
        }
    }

    void DestroyCheck(){
        foreach(Entity ally in myEntities){
            if(ally.health <= 0 && (ally.isUnit || ally.isTower)){
                DestroyEntity(ally.thisentity, true);
                break;
            }
            if(ally.isMagic && ally.magicShot){
                DestroyEntity(ally.thisentity, true, true);
                break;
            }
        }
        foreach(Entity enemy in EnemyEntities){
            if(enemy.health <= 0){
                DestroyEntity(enemy.thisentity, false);
                break;
            }
        }
    }

    public void DestroyEntity(GameObject gameObject, bool isAlly, bool isMagic = false){
        if(isMagic) Destroy(gameObject, 1f);
        else Destroy(gameObject, 3f);

        if(isAlly)
            myEntities.Remove(gameObject.GetComponent<Entity>());
        else{
            EnemyEntities.Remove(gameObject.GetComponent<Entity>());
            if(cardManager.myCost < 20){
                if(cardManager.myCost == 19) ++cardManager.myCost;
                else cardManager.myCost += 2;
            }
        }
    }

    public void SpawnMiniBoss(EnemySO enemyso)
    {
        Enemy[] enemies = enemyso.enemies;

        Enemy randenemy = enemies[3];
        var enemyObject = Instantiate(randenemy.prefabs, EnemySpawnPointRight.position, Utils.QI);
        var enemyentity = enemyObject.GetComponent<Entity>();
        enemyentity.SetupEnemy(randenemy);
        enemyentity.thisentity = enemyObject;
        EnemyEntities.Add(enemyentity);
        spawnTimer = 0f;
    }

    public void SpawnFinalBoss(EnemySO enemyso)
    {
        Enemy[] enemies = enemyso.enemies;

        Enemy randenemy = enemies[4];
        var enemyObject = Instantiate(randenemy.prefabs, EnemySpawnPointRight.position, Utils.QI);
        var enemyentity = enemyObject.GetComponent<Entity>();
        enemyentity.SetupEnemy(randenemy);
        enemyentity.thisentity = enemyObject;
        EnemyEntities.Add(enemyentity);
        spawnTimer = 0f;
    }

    void Start(){
        isSpawn = true;
        if (TimeUI.Wave == 3)
        {
            SpawnMiniBoss(enemyso);
        }
        if (TimeUI.Wave == 5)
        {
            SpawnFinalBoss(enemyso);
        }
    }

    void Update(){
        SpawnEnemy(enemyso);
        DestroyCheck();
    }
}
