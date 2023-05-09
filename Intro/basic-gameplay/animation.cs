void Start(){
    mAnimator = GetComponent<Animator>();
}

void update(){
    if (mAnimator != null)
    {
        //create triggers in unity and attach them to prefab animations
        if (Input.GetKeyDown(KeyCode.O))
        {
            mAnimator.SetTrigger("TrOpen")
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mAnimator.SetTrigger("TrClose")
        }
    }
}