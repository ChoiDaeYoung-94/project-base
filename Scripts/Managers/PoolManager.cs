using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD
{
    /// <summary>
    /// Pool 관리
    /// </summary>
    public class PoolManager
    {
        #region Pool
        public class Pool
        {
            /// <summary>
            /// Pool에 생성할 GameObject
            /// </summary>
            public GameObject GO_poolTarget { get; private set; }

            /// <summary>
            /// Pool에 생성할 GameObject의 root Transform
            /// </summary>
            public Transform Root { get; set; }

            /// <summary>
            /// 생성된 PoolObject Stack으로 관리, 메서드로 Push, Pop 관리
            /// </summary>
            Stack<PoolObject> _Stack_pool = new Stack<PoolObject>();

            /// <summary>
            /// Pool 생성 시 Init
            /// -> Pool아래에 생성할 오브젝트의 Root 생성 후 create
            /// </summary>
            /// <param name="go"></param>
            /// <param name="go_name"></param>
            /// <param name="count"></param>
            public void Init(GameObject go, string go_name, int count)
            {
                GO_poolTarget = go;

                Root = new GameObject().transform;
                Root.name = $"{go_name}";

                // count만큼 pool로
                for (int i = -1; ++i < count;)
                    PushToPool(Create());
            }

            /// <summary>
            /// GO_poolTarget 생성 후 PoolObject반환
            /// </summary>
            PoolObject Create()
            {
                GameObject go = Object.Instantiate(GO_poolTarget);
                go.name = GO_poolTarget.name;

                PoolObject poolObj = go.GetComponent_<PoolObject>();

                return poolObj;
            }

            /// <summary>
            /// 생성된 go의 root를 맞추고 비활성화 후 stack에 push
            /// </summary>
            /// <param name="poolObj"></param>
            public void PushToPool(PoolObject poolObj)
            {
                poolObj.transform.parent = Root;
                poolObj.gameObject.SetActive(false);

                _Stack_pool.Push(poolObj);
            }

            /// <summary>
            /// Stack에서 Pop을 할 때 Stack이 비워있을 경우 Create
            /// 사용할 것이니까 활성화 후 transform 정리
            /// </summary>
            /// <param name="parent"></param>
            /// <returns></returns>
            public void PopFromPool(Transform parent)
            {
                PoolObject poolObj;

                if (_Stack_pool.Count > 0)
                    poolObj = _Stack_pool.Pop();
                else
                    poolObj = Create();

                poolObj.gameObject.SetActive(true);

                if (parent == null)
                {
                    Transform tr = null;

                    if (GameObject.Find("ActivePool") == null)
                        tr = new GameObject { name = "ActivePool" }.transform;
                    else
                        tr = GameObject.Find("ActivePool").transform;

                    poolObj.transform.parent = tr;
                }
                else
                    poolObj.transform.parent = parent;
            }
        }
        #endregion

        [Tooltip("Pool 관리 할 Dictionary - _root아래의 생성할 poolGO.name, Pool로 관리")]
        public Dictionary<string, Pool> _dic_pool = new Dictionary<string, Pool>();

        [Tooltip("Pool의 root Transform")]
        public Transform _root;

        /// <summary>
        /// Managers - Awake() -> Init()
        /// Pool에 둬야 할 것들 미리 생성
        /// </summary>
        public void Init()
        {
            // root 생성
            if (_root == null)
            {
                _root = new GameObject { name = "Pool" }.transform;
                Object.DontDestroyOnLoad(_root);
            }
        }

        /// <summary>
        /// Pool 생성 (기본 5개 씩)
        /// </summary>
        /// <param name="go"></param>
        /// <param name="go_name"></param>
        /// <param name="count"></param>
        public void CreatePool(GameObject go, string go_name, int count = 5)
        {
            Pool pool = new Pool();
            pool.Init(go, go_name, count);
            pool.Root.parent = _root;

            _dic_pool.Add(go_name, pool);
        }

        /// <summary>
        /// 사용한 PoolObj를 Pool에 다시 Push
        /// </summary>
        /// <param name="go"></param>
        public void PushToPool(GameObject go)
        {
            PoolObject poolObj = go.GetComponent<PoolObject>();

            if (!_dic_pool.ContainsKey(go.name))
            {
                Object.Destroy(go);
                return;
            }

            // Stack으로 push
            _dic_pool[go.name].PushToPool(poolObj);
        }

        /// <summary>
        /// _dic_pool에서 Pool에 있는 사용할 go를 Pop
        /// </summary>
        /// <param name="go_name"></param>
        /// <param name="parent"></param>
        public void PopFromPool(string go_name, Transform parent = null)
        {
            if (!_dic_pool.ContainsKey(go_name))
            {
                AD.Debug.Contain("PoolManager", $"{go_name} in _dic_pool");
                return;
            }

            _dic_pool[go_name].PopFromPool(parent);
        }

        /// <summary>
        /// Pool 날릴 때 사용
        /// 현재 Managers - Clear()에 주석 처리 중
        /// </summary>
        public void Clear()
        {
            foreach (Transform child in _root)
                GameObject.Destroy(child.gameObject);

            _dic_pool.Clear();
        }
    }
}