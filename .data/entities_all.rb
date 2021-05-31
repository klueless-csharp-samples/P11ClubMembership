class EntitiesAll
  include EntityMethods

  def initialize
    @entities = []

    definition

    apply_aliases
  end

  def definition
    entity model_name: :user,
           model_name_plural: :users do

      column      :email                                   , type: :string    
      column      :password                                , type: :string    
      column      :role                                    , type: :string    
      column      :status                                  , type: :string    
    
    end

    entity model_name: :member,
           model_name_plural: :members do

      column      :first_name                              , type: :string    
      column      :last_name                               , type: :string    
      column      :email                                   , type: :string    
      column      :phone                                   , type: :string    
      column      :birth_date                              , type: :datatime      
    end
  end
end
